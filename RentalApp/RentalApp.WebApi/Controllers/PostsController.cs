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
	//[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
	public class PostsController : ControllerBase
	{
		private readonly IPostsService _postsService;
		private readonly IDepositsService _depositsService;
		private readonly IDepositStatusesService _depositStatusesService;

		public PostsController(IPostsService postsService, IDepositsService depositsService)
		{
			_postsService = postsService;
			_depositsService = depositsService;
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
			if (newPostDto.RequestDepositDto == null)
				return NotFound("Deposit can not be null");

			if (newPostDto.CreatePostImageDto == null)
				return NotFound("Image can not be null");

			if(newPostDto.RequestDepositDto.CreateDepositStatusDto == null)
				return NotFound("Image can not be null");

			//todo zapytac Adama czy tak wgl mozna?
			var newDepositStatus = await _depositStatusesService.CreateDepositStatus(newPostDto.RequestDepositDto.CreateDepositStatusDto);

			CreateDepositDto createDepositDto = new CreateDepositDto
			{
				Value = newPostDto.RequestDepositDto.Value,
				StatusId = newDepositStatus.Id
			};

			var newDeposit = await _depositsService.CreateDeposit(createDepositDto);

			//todo Zapytam Adama jak to ogarnac? Nie pobiera? Pobierac?
			newPostDto.UserId = User.GetId();

			CreatePostDto createPostDto = new CreatePostDto
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
			};

			var newPost = await _postsService.CreatePost(createPostDto);

			return Created($"api/posts/{newPost.Id}", newPost);
		}
	}
}
