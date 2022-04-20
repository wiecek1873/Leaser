using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using RentalApp.Application.Interfaces;
using RentalApp.WebApi.Filters;
using RentalApp.Application.Dto.Posts;
using RentalApp.WebApi.Extensions;
using RentalApp.Application.Dto.Deposits;

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

		[HttpPost("{categoryId}")]
		[SwaggerOperation(Summary = "Add new post in the app")]
		public async Task<IActionResult> AddPost([FromRoute] int categoryId, [FromForm] CreatePostDto newPostDto, [FromForm] CreatePostImageDto newPostImageDto)
		{
			//todo zapytac Adama czy tak wgl mozna?
			// var newDepositStatus = await _depositStatusesService.CreateDepositStatus(newPostDto.CreateDepositDto.CreateDepositStatusDto); => raczej do wywalenia


			//todo Zapytam Adama jak to ogarnac? Nie pobiera? Pobierac?
			// bez sensu do dto przypisywać rzeczy DTO to dane, kóre dostajemy od klienta w jsonie
			// newPostDto.UserId = User.GetId(); => do wywalenia

			/*CreatePostDto createPostDto = new CreatePostDto => po co przypisac z jednego dto do drugiego DTO rzeczy do wywalenia dto to tak naprawde dane, ktore
			 * otrzymujemy od klienta
			{
				UserId = newPostDto.UserId,
				CategoryId = newPostDto.CategoryId,
				Title = newPostDto.Title,
				Description = newPostDto.Description,
				DepositId = newDeposit.Id,
				Price = newPostDto.Price,
				PricePerWeek = newPostDto.PricePerWeek,
				PricePerMonth = newPostDto.PricePerMonth,
				AvailableFrom = newPostDto.AvailableFrom,
				AvailableTo = newPostDto.AvailableTo,
				Image = newPostDto.CreatePostImageDto.PostImage
			};*/

			var newPost = await _postsService.CreatePost(categoryId, User.GetId(), newPostDto, newPostImageDto);

			return Created($"api/posts/{newPost.Id}", newPost);
		}
	}
}
