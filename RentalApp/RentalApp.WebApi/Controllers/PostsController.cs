using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using RentalApp.Application.Interfaces;
using RentalApp.WebApi.Filters;
using RentalApp.Application.Dto.Posts;
using RentalApp.WebApi.Extensions;
using System.Collections.Generic;

namespace RentalApp.WebApi.Controllers
{
	[ApiController]
	[GlobalExceptionFilter]
	[Route("api/[controller]")]
	[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
	public class PostsController : ControllerBase
	{
		private readonly IPostsService _postsService;
		private readonly IUsersService _usersService;

		public PostsController(IPostsService postsService, IUsersService usersService)
		{
			_postsService = postsService;
			_usersService = usersService;
		}

		[HttpGet("{postId}")]
		[SwaggerOperation(Summary = "Get a post")]
		public async Task<IActionResult> GetPost(int postId)
		{
			var post = await _postsService.GetPost(postId);

			return Ok(post);
		}

		[HttpGet("{postId}/Image")] 
		[SwaggerOperation(Summary = "Get post image")]
		public async Task<IActionResult> GetPostImage(int postId)
		{
			var postImage = await _postsService.GetPostImage(postId);

			return File(postImage.PostImage, "image/jpeg");
		}

		[HttpGet("{categoryId}/Category")]
		[SwaggerOperation(Summary = "Get posts from category")]
		public async Task<IActionResult> GetPostsByCategory([FromRoute] int categoryId)
		{
			var posts = await _postsService.GetPostsByCategory(categoryId);

			return Ok(posts);
		}

		[HttpGet("{categoryId}/Category/User")]
		[SwaggerOperation(Summary = "Get posts from category with user information")]
		public async Task<IActionResult> GetUserPostsByCategory([FromRoute] int categoryId)
		{
			var userPosts = new List<UserPostDto>();
			var posts = await _postsService.GetPostsByCategory(categoryId);

			foreach (var post in posts)
			{
				var user = await _usersService.GetUser(post.UserId.ToString());
				var userPost = new UserPostDto
				{
					Id = post.Id,
					CategoryId = post.CategoryId,
					UserId = post.UserId,
					UserNickName = user.NickName,
					Rating = user.Rating,
					Title = post.Title,
					Description = post.Description,
					DepositId = post.DepositId,
					Price = post.Price,
					PricePerWeek = post.PricePerWeek,
					PricePerMonth = post.PricePerWeek,
					AvailableFrom = post.AvailableFrom,
					AvailableTo = post.AvailableTo,
				};
				userPosts.Add(userPost);
			}

			return Ok(userPosts);
		}

		[HttpGet("{userId}/User")]
		[SwaggerOperation(Summary ="Get user posts")]
		public async Task<IActionResult> GetPostsByUserId([FromRoute] string userId)
		{
			var posts = await _postsService.GetPostsByUserId(userId);

			return Ok(posts);
		}

		[HttpPost("{categoryId}")]
		[SwaggerOperation(Summary = "Add new post in the app")]
		public async Task<IActionResult> AddPost([FromRoute] int categoryId, [FromForm] RequestPostDto newPostDto, [FromForm] RequestPostImageDto newPostImageDto)
		{
			var newPost = await _postsService.CreatePost(categoryId, User.GetId(), newPostDto, newPostImageDto);

			return Created($"api/posts/{newPost.Id}", newPost);
		}

		[HttpPut("{postId}/{categoryId}")]
		[SwaggerOperation(Summary = "Update a post")]
		public async Task<IActionResult> UpdatePost([FromRoute] int postId, [FromRoute] int categoryId, [FromForm] RequestPostDto newPostDto, [FromForm] RequestPostImageDto newPostImageDto)
		{
			await _postsService.UpdatePost(postId, categoryId, User.GetId(), newPostDto, newPostImageDto);

			return Ok();
		}

		[HttpDelete("{postId}")]
		[SwaggerOperation(Summary = "Delete a post")]
		public async Task<IActionResult> DeletePost(int postId)
		{
			await _postsService.DeletePost(postId, User.GetId());

			return Ok();
		}
	}
}
