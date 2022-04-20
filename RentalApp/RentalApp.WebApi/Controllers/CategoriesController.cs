using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using RentalApp.Application.Interfaces;
using RentalApp.WebApi.Filters;
using RentalApp.Application.Dto.Posts;
using RentalApp.WebApi.Extensions;
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
		public async Task<IActionResult> GetCategory(int categoryId)
		{
			var category = await _categoriesService.GetCategory(categoryId);

			return Ok(category);
		}

		[HttpPost]
		public async Task<IActionResult> AddCategory([FromBody] RequestCategoryDto requestCategoryDto)
		{
			var newCategory = await _categoriesService.CreateCategory(requestCategoryDto);

			return Created($"api/users/{newCategory.Id}", newCategory);
		}

		[HttpPut("{depositId}")]
		public async Task<IActionResult> UpdateDeposit([FromRoute] int categoryId, RequestCategoryDto updatedCategoryDto)
		{
			await _categoriesService.UpdateCategory(categoryId, updatedCategoryDto);

			return NoContent();
		}
	}
}
