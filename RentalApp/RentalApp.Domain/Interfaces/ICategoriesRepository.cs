using System.Threading.Tasks;
using RentalApp.Domain.Entities;

namespace RentalApp.Domain.Interfaces
{
	interface ICategoriesRepository
	{
		Task<Category> GetCategory(int categoryId);
		Task<Category> AddCategory(Category newCategory);
		Task UpdateCategory(int categoryId, Category updatedCategory);
	}
}
