using System.Threading.Tasks;
using RentalApp.Application.Dto.Categories;

namespace RentalApp.Application.Interfaces
{
	public interface ICategoriesService
	{
		Task<CategoryDto> GetCategory(int categoryId);
		Task<CategoryDto> CreateCategory(RequestCategoryDto  newCategoryDto);
		public Task UpdateCategory(int categoryId, RequestCategoryDto updatedCategoryDto);
	}
}
