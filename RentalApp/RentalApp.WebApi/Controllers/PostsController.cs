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
		//private readonly IDepositsService _depositsService;
		//private readonly IDepositStatusesService _depositStatusesService; // ja był zaimplemntował to inaczej i stworzył osobny kontroler na depozyt status
		// front bedzie musiał wykonać kilka requestów wiecej, ale nie bd tak, że bedzie dto w dto w dto bo troche spaghetti code zaraz z tego bedzie
		// 1. Tworzymy Depozyt
		// 2. Podczas tworzenia depozytu, bedzie automatycznie dodawana jakaś stały status -> typu utowrzony, trzeba sie z Klaudia zastanowić czy to ma byc jakis enum czy jak
		// 3. tworzy deposit, gdzie w dto bedzie trzeba przeslac już deposyt status, który front sobie już szybciej utowrzy przed wysłaniem requesty na stworzenie depozytu
		// 4. front bedzie miał id statusu wiec moze wysłać requesta tworzącego depozyt, gdzie w odpowiedzi otrzyma id utowrzonego depozytu
		// 5. w dto stworzonego postu dodajemy id depozytu wcześniej utworzonego lub wgl go nie dodajemy
		// 6. ale nas jako serwer tworzac SAM post nie obchodzi czy depozyt jest utowrzony czy nie
		// 7. Jest to zgodne z zasadami SOLID - metody towrzące status tworzą status, metody tworzące depozyt tworzą depozyt

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

		[HttpPost]
		[SwaggerOperation(Summary = "Add new post in the app")]
		//todo zapytać Adama czemu jak jest [FromForm] to działa. A jak jest [FormBody] to nie działa
		// tak pobieranie pliku musi mieć [FromFrom] bo to nie bd juz typowy json bo jest tam zdjecie przesyłane
		// dodatkowo trzeba osobno przeslac dane i zdjecie
		public async Task<IActionResult> AddPost([FromForm] CreatePostDto newPostDto, [FromForm] CreatePostImageDto newPostImageDto)
		{
			/* NA POZIOMIE kontrtolera nie obłsugujmey logiki aplikacji to powinno byc zaimplementowane w serwisie
			 * 
			 * Jezeli jakis atrybut jest nullem lepiej zwracac Bad Request czyli 400, a nie not found
			 * 404 oznacze ze zasobu nie ma w bazi danych a nie, że jest przesłany w zlej formie
			 * 
			if (newPostDto.RequestDepositDto == null)
				return NotFound("Deposit can not be null");

			if (newPostDto.CreatePostImageDto == null)
				return NotFound("Image can not be null");

			if(newPostDto.RequestDepositDto.CreateDepositStatusDto == null)
				return NotFound("Image can not be null");*/

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

			var newPost = await _postsService.CreatePost(User.GetId(), newPostDto, newPostImageDto);

			return Created($"api/posts/{newPost.Id}", newPost);
		}
	}
}
