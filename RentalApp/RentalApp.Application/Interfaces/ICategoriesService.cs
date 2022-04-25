using System.Collections.Generic;
using System.Threading.Tasks;
using RentalApp.Application.Dto.Categories;

namespace RentalApp.Application.Interfaces
{
	public interface ICategoriesService
	{
		Task<List<CategoryDto>> GetCategories();

		Task<CategoryDto> GetCategory(int categoryId);

		Task<CategoryDto> CreateCategory(RequestCategoryDto  newCategoryDto);

		Task UpdateCategory(int categoryId, RequestCategoryDto updatedCategoryDto);
	}
}
