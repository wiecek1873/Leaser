using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Swashbuckle.AspNetCore.Annotations;
using RentalApp.Application.Interfaces;
using RentalApp.WebApi.Filters;
using RentalApp.Application.Dto.Categories;

namespace RentalApp.WebApi.Controllers
{
	[ApiController]
	[GlobalExceptionFilter]
	[Route("api/[controller]")]
	[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
	public class CategoriesController : ControllerBase
	{
		private readonly ICategoriesService _categoriesService;

		public CategoriesController (ICategoriesService categoriesService)
		{
			_categoriesService = categoriesService;
		}

		[HttpGet]
		[SwaggerOperation(Summary = "Get all categories")]
		public async Task<IActionResult> GetCategories()
		{
			var categories = await _categoriesService.GetCategories();

			return Ok(categories);
		}

		[HttpGet("{categoryId}")]
		[SwaggerOperation(Summary = "Get category by id")]
		public async Task<IActionResult> GetCategory(int categoryId)
		{
			var category = await _categoriesService.GetCategory(categoryId);

			return Ok(category);
		}

		[HttpPost]
		[SwaggerOperation(Summary = "Add a new category")]
		public async Task<IActionResult> AddCategory([FromBody] RequestCategoryDto requestCategoryDto)
		{
			var newCategory = await _categoriesService.CreateCategory(requestCategoryDto);

			return Created($"api/categories/{newCategory.Id}", newCategory);
		}

		[HttpPut("{categoryId}")]
		[SwaggerOperation(Summary = "Update a selected category by id")]
		public async Task<IActionResult> UpdateCategory([FromRoute] int categoryId, [FromBody] RequestCategoryDto updatedCategoryDto)
		{
			await _categoriesService.UpdateCategory(categoryId, updatedCategoryDto);

			return NoContent();
		}
	}
}
