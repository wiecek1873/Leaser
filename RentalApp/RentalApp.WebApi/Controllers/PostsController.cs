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
	public class PostsController : ControllerBase
	{
		private readonly IPostsService _postsService;
		
		public PostsController(IPostsService postsService)
		{
			_postsService = postsService;
		}

		[HttpGet]
		[Route("Post")]
		[AllowAnonymous]
		[SwaggerOperation(Summary = "Get a post")]
		public async Task<IActionResult> GetPost()
		{
			var post = await _postsService.GetPost(post);

			return Ok(post);
		}


		[HttpPost]
		[Route("Add Post")]
		[AllowAnonymous]
		[SwaggerOperation(Summary = "Add new post in the app")]
		public async Task<IActionResult> AddPost([FromBody] CreatePostDto newPostDto)
		{
			var newPost = await _postsService.CreatePost(newPostDto);

			return Created($"api/posts/{newPost.Id}", newPost);
		}
	}
}
