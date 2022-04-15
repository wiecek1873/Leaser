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
	//[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
	public class PostsController : ControllerBase
	{
		private readonly IPostsService _postsService;
		private readonly IDepositsService _depositsService;

		public PostsController(IPostsService postsService)
		{
			_postsService = postsService;
		}

		[HttpGet("{postId}")]
		[AllowAnonymous]
		[SwaggerOperation(Summary = "Get a post")]
		public async Task<IActionResult> GetPost(int postId)
		{
			var post = await _postsService.GetPost(postId);

			return Ok(post);
		}

		[HttpPost]
		[AllowAnonymous]
		[SwaggerOperation(Summary = "Add new post in the app")]
		//todo zapytać Adama czemu jak jest [FromForm] to działa. A jak jest [FormBody] to nie działa
		public async Task<IActionResult> AddPost([FromForm] RequestPostDto newPostDto)
		{
			if(newPostDto.DepositValue == null)
				return NotFound("Deposit can not be null");

			//todo Zapytam Adama jak to ogarnac? Nie pobiera? Pobierac?
			newPostDto.UserId = User.GetId();

			var newPost = await _postsService.CreatePost(newPostDto);

			return Created($"api/posts/{newPost.Id}", newPost);
		}
	}
}
