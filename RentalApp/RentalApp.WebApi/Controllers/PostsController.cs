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
using System.Linq;

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
		private readonly IAddressesService _addressesService;

		public PostsController(IPostsService postsService, IUsersService usersService, IAddressesService addressesService)
		{
			_postsService = postsService;
			_usersService = usersService;
			_addressesService = addressesService;
		}

		[HttpGet("{postId}")]
		[SwaggerOperation(Summary = "Get a post")]
		public async Task<IActionResult> GetPost(int postId)
		{
			var post = await _postsService.GetPost(postId);

			var user = await _usersService.GetUser(post.UserId.ToString());
			Application.Dto.Addresses.AddressDto address = new Application.Dto.Addresses.AddressDto();

			if (user.AddressId.HasValue)
				address = await _addressesService.GetUserAddress(user.AddressId.Value);

			var detailPost = new DetailPostDto
			{
				Id = post.Id,
				CategoryId = post.CategoryId,
				UserId = post.UserId,
				UserNickName = user.NickName,
				PhoneNumber = user.PhoneNumber,
				Rating = user.Rating,
				Title = post.Title,
				Description = post.Description,
				Price = post.Price,
				DepositValue = post.DepositValue,
				PricePerWeek = post.PricePerWeek,
				PricePerMonth = post.PricePerMonth,
				AvailableFrom = post.AvailableFrom,
				AvailableTo = post.AvailableTo,
				Country = address?.Country,
				City = address?.City,
				Street = address?.Street,
				BuildingNo = address?.BuildingNo,
				ApartmentNo = address?.ApartmentNo,
				PostalCode = address?.PostalCode,
			};

			return Ok(detailPost);
		}

		[HttpGet]
		[SwaggerOperation(Summary = "Get posts")]
		public async Task<IActionResult> GetPosts()
		{
			var posts = await _postsService.GetPosts();

			return Ok(posts);
		}

		[HttpGet("Detail")]
		[SwaggerOperation(Summary = "Get detail posts")]
		public async Task<IActionResult> GetDetailPosts()
		{
			var detailPosts = new List<DetailPostDto>();
			var posts = await _postsService.GetPosts();

			foreach (var post in posts)
			{
				var user = await _usersService.GetUser(post.UserId.ToString());
				Application.Dto.Addresses.AddressDto address = new Application.Dto.Addresses.AddressDto();

				if (user.AddressId.HasValue)
					address = await _addressesService.GetUserAddress(user.AddressId.Value);

				var detailPost = new DetailPostDto
				{
					Id = post.Id,
					CategoryId = post.CategoryId,
					UserId = post.UserId,
					UserNickName = user.NickName,
					Rating = user.Rating,
					Title = post.Title,
					Description = post.Description,
					Price = post.Price,
					DepositValue = post.DepositValue,
					PricePerWeek = post.PricePerWeek,
					PricePerMonth = post.PricePerMonth,
					AvailableFrom = post.AvailableFrom,
					AvailableTo = post.AvailableTo,
					Country = address?.Country,
					City = address?.City,
					Street = address?.Street,
					BuildingNo = address?.BuildingNo,
					ApartmentNo = address?.ApartmentNo,
					PostalCode = address?.PostalCode,
				};
				detailPosts.Add(detailPost);
			}

			return Ok(detailPosts);
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

		[HttpGet("{categoryId}/Category/Detail")]
		[SwaggerOperation(Summary = "Get posts from category with user  and address information")]
		public async Task<IActionResult> GetDetailPostsByCategory([FromRoute] int categoryId)
		{
			var detailPosts = new List<DetailPostDto>();
			var posts = await _postsService.GetPostsByCategory(categoryId);

			foreach (var post in posts)
			{
				var user = await _usersService.GetUser(post.UserId.ToString());
				Application.Dto.Addresses.AddressDto address = new Application.Dto.Addresses.AddressDto();

				if (user.AddressId.HasValue)
					address = await _addressesService.GetUserAddress(user.AddressId.Value);

				var detailPost = new DetailPostDto
				{
					Id = post.Id,
					CategoryId = post.CategoryId,
					UserId = post.UserId,
					UserNickName = user.NickName,
					Rating = user.Rating,
					Title = post.Title,
					Description = post.Description,
					Price = post.Price,
					DepositValue = post.DepositValue,
					PricePerWeek = post.PricePerWeek,
					PricePerMonth = post.PricePerMonth,
					AvailableFrom = post.AvailableFrom,
					AvailableTo = post.AvailableTo,
					Country = address?.Country,
					City = address?.City,
					Street = address?.Street,
					BuildingNo = address?.BuildingNo,
					ApartmentNo = address?.ApartmentNo,
					PostalCode = address?.PostalCode,
				};
				detailPosts.Add(detailPost);
			}

			return Ok(detailPosts);
		}

		[HttpGet("{userId}/User")]
		[SwaggerOperation(Summary = "Get user posts")]
		public async Task<IActionResult> GetPostsByUserId([FromRoute] string userId)
		{
			var posts = await _postsService.GetPostsByUserId(userId);

			return Ok(posts);
		}

		[HttpGet("{userId}/User/Detail")]
		[SwaggerOperation(Summary = "Get user posts with user and address information")]
		public async Task<IActionResult> GetUserPostsByUserId([FromRoute] string userId)
		{
			var detailPosts = new List<DetailPostDto>();
			var posts = await _postsService.GetPostsByUserId(userId);

			foreach (var post in posts)
			{
				var user = await _usersService.GetUser(post.UserId.ToString());
				Application.Dto.Addresses.AddressDto address = new Application.Dto.Addresses.AddressDto();

				if (user.AddressId.HasValue)
					address = await _addressesService.GetUserAddress(user.AddressId.Value);

				var detailPost = new DetailPostDto
				{
					Id = post.Id,
					CategoryId = post.CategoryId,
					UserId = post.UserId,
					UserNickName = user.NickName,
					PhoneNumber = user.PhoneNumber,
					Rating = user.Rating,
					Title = post.Title,
					Description = post.Description,
					Price = post.Price,
					DepositValue = post.DepositValue,
					PricePerWeek = post.PricePerWeek,
					PricePerMonth = post.PricePerMonth,
					AvailableFrom = post.AvailableFrom,
					AvailableTo = post.AvailableTo,
					Country = address?.Country,
					City =  address?.City,
					Street = address?.Street,
					BuildingNo = address?.BuildingNo,
					ApartmentNo = address?.ApartmentNo,
					PostalCode =  address?.PostalCode,
				};
				detailPosts.Add(detailPost);
			}

			return Ok(detailPosts);
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

		[HttpGet("{categoryId}/Category/Detail/PriceAscending")]
		[SwaggerOperation(Summary = "Get posts from category by Price Ascending")]
		public async Task<IActionResult> GetPostsByPriceAscending([FromRoute] int categoryId)
		{
			var detailPosts = new List<DetailPostDto>();
			var posts = await _postsService.GetPostsByPriceAscending(categoryId);

			foreach (var post in posts)
			{
				var user = await _usersService.GetUser(post.UserId.ToString());
				Application.Dto.Addresses.AddressDto address = new Application.Dto.Addresses.AddressDto();

				if (user.AddressId.HasValue)
					address = await _addressesService.GetUserAddress(user.AddressId.Value);

				var detailPost = new DetailPostDto
				{
					Id = post.Id,
					CategoryId = post.CategoryId,
					UserId = post.UserId,
					UserNickName = user.NickName,
					PhoneNumber = user.PhoneNumber,
					Rating = user.Rating,
					Title = post.Title,
					Description = post.Description,
					Price = post.Price,
					DepositValue = post.DepositValue,
					PricePerWeek = post.PricePerWeek,
					PricePerMonth = post.PricePerMonth,
					AvailableFrom = post.AvailableFrom,
					AvailableTo = post.AvailableTo,
					Country = address?.Country,
					City = address?.City,
					Street = address?.Street,
					BuildingNo = address?.BuildingNo,
					ApartmentNo = address?.ApartmentNo,
					PostalCode = address?.PostalCode,
				};
				detailPosts.Add(detailPost);
			}

			return Ok(detailPosts);
		}

		[HttpGet("{categoryId}/Category/Detail/PriceDescending")]
		[SwaggerOperation(Summary = "Get posts from category by Price Ascending")]
		public async Task<IActionResult> GetPostsByPriceDescending([FromRoute] int categoryId)
		{
			var detailPosts = new List<DetailPostDto>();
			var posts = await _postsService.GetPostsByPriceDescending(categoryId);

			foreach (var post in posts)
			{
				var user = await _usersService.GetUser(post.UserId.ToString());
				Application.Dto.Addresses.AddressDto address = new Application.Dto.Addresses.AddressDto();

				if (user.AddressId.HasValue)
					address = await _addressesService.GetUserAddress(user.AddressId.Value);

				var detailPost = new DetailPostDto
				{
					Id = post.Id,
					CategoryId = post.CategoryId,
					UserId = post.UserId,
					UserNickName = user.NickName,
					PhoneNumber = user.PhoneNumber,
					Rating = user.Rating,
					Title = post.Title,
					Description = post.Description,
					Price = post.Price,
					DepositValue = post.DepositValue,
					PricePerWeek = post.PricePerWeek,
					PricePerMonth = post.PricePerMonth,
					AvailableFrom = post.AvailableFrom,
					AvailableTo = post.AvailableTo,
					Country = address?.Country,
					City = address?.City,
					Street = address?.Street,
					BuildingNo = address?.BuildingNo,
					ApartmentNo = address?.ApartmentNo,
					PostalCode = address?.PostalCode,
				};
				detailPosts.Add(detailPost);
			}

			return Ok(detailPosts);
		}

		[HttpGet("{categoryId}/Category/Detail/RateAscending")]
		[SwaggerOperation(Summary = "Get posts from category by Rate Ascending")]
		public async Task<IActionResult> GetPostsByRateAscending([FromRoute] int categoryId)
		{
			var detailPosts = new List<DetailPostDto>();
			var posts = await _postsService.GetPostsByCategory(categoryId);

			foreach (var post in posts)
			{
				var user = await _usersService.GetUser(post.UserId.ToString());
				Application.Dto.Addresses.AddressDto address = new Application.Dto.Addresses.AddressDto();

				if (user.AddressId.HasValue)
					address = await _addressesService.GetUserAddress(user.AddressId.Value);

				var detailPost = new DetailPostDto
				{
					Id = post.Id,
					CategoryId = post.CategoryId,
					UserId = post.UserId,
					UserNickName = user.NickName,
					PhoneNumber = user.PhoneNumber,
					Rating = user.Rating,
					Title = post.Title,
					Description = post.Description,
					Price = post.Price,
					DepositValue = post.DepositValue,
					PricePerWeek = post.PricePerWeek,
					PricePerMonth = post.PricePerMonth,
					AvailableFrom = post.AvailableFrom,
					AvailableTo = post.AvailableTo,
					Country = address?.Country,
					City = address?.City,
					Street = address?.Street,
					BuildingNo = address?.BuildingNo,
					ApartmentNo = address?.ApartmentNo,
					PostalCode = address?.PostalCode,
				};
				detailPosts.Add(detailPost);
			}

			return Ok(detailPosts.AsEnumerable().OrderBy(p => p.Rating));
		}

		[HttpGet("{categoryId}/Category/Detail/RateDescending")]
		[SwaggerOperation(Summary = "Get posts from category by Rate Descending")]
		public async Task<IActionResult> GetPostsByRateDescending([FromRoute] int categoryId)
		{
			var detailPosts = new List<DetailPostDto>();
			var posts = await _postsService.GetPostsByCategory(categoryId);

			foreach (var post in posts)
			{
				var user = await _usersService.GetUser(post.UserId.ToString());
				Application.Dto.Addresses.AddressDto address = new Application.Dto.Addresses.AddressDto();

				if (user.AddressId.HasValue)
					address = await _addressesService.GetUserAddress(user.AddressId.Value);

				var detailPost = new DetailPostDto
				{
					Id = post.Id,
					CategoryId = post.CategoryId,
					UserId = post.UserId,
					UserNickName = user.NickName,
					PhoneNumber = user.PhoneNumber,
					Rating = user.Rating,
					Title = post.Title,
					Description = post.Description,
					Price = post.Price,
					DepositValue = post.DepositValue,
					PricePerWeek = post.PricePerWeek,
					PricePerMonth = post.PricePerMonth,
					AvailableFrom = post.AvailableFrom,
					AvailableTo = post.AvailableTo,
					Country = address?.Country,
					City = address?.City,
					Street = address?.Street,
					BuildingNo = address?.BuildingNo,
					ApartmentNo = address?.ApartmentNo,
					PostalCode = address?.PostalCode,
				};
				detailPosts.Add(detailPost);
			}

			return Ok(detailPosts.AsEnumerable().OrderByDescending(p => p.Rating));
		}

		[HttpGet("{phrase}/Detail")]
		[SwaggerOperation(Summary = "Get posts by phrase")]
		public async Task<IActionResult> GetPostsByPhrase([FromRoute] string phrase)
		{
			var detailPosts = new List<DetailPostDto>();
			var posts = await _postsService.GetPostsByPhrase(phrase);

			foreach (var post in posts)
			{
				var user = await _usersService.GetUser(post.UserId.ToString());
				Application.Dto.Addresses.AddressDto address = new Application.Dto.Addresses.AddressDto();

				if (user.AddressId.HasValue)
					address = await _addressesService.GetUserAddress(user.AddressId.Value);

				var detailPost = new DetailPostDto
				{
					Id = post.Id,
					CategoryId = post.CategoryId,
					UserId = post.UserId,
					UserNickName = user.NickName,
					PhoneNumber = user.PhoneNumber,
					Rating = user.Rating,
					Title = post.Title,
					Description = post.Description,
					Price = post.Price,
					DepositValue = post.DepositValue,
					PricePerWeek = post.PricePerWeek,
					PricePerMonth = post.PricePerMonth,
					AvailableFrom = post.AvailableFrom,
					AvailableTo = post.AvailableTo,
					Country = address?.Country,
					City = address?.City,
					Street = address?.Street,
					BuildingNo = address?.BuildingNo,
					ApartmentNo = address?.ApartmentNo,
					PostalCode = address?.PostalCode,
				};
				detailPosts.Add(detailPost);
			}

			return Ok(detailPosts.AsEnumerable().OrderByDescending(p => p.Rating));

		}
	}
}
