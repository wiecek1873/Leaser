using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using RentalApp.Application.Interfaces;
using RentalApp.WebApi.Filters;
using RentalApp.Application.Dto.Posts;
using RentalApp.WebApi.Extensions;

namespace RentalApp.WebApi.Controllers
{
	[ApiController]
	[GlobalExceptionFilter]
	[Route("api/[controller]")]
	[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
	public class PostsController : ControllerBase
	{
		private readonly IPostsService _postsService;

		public PostsController(IPostsService postsService)
		{
			_postsService = postsService;
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
