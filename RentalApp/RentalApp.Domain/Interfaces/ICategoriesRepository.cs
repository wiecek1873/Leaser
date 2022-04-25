using System.Collections.Generic;
using System.Threading.Tasks;
using RentalApp.Domain.Entities;

namespace RentalApp.Domain.Interfaces
{
	public interface ICategoriesRepository
	{
		Task<List<Category>> GetCategories();

		Task<Category> GetCategory(int categoryId);

		Task<Category> AddCategory(Category newCategory);

		Task UpdateCategory(int categoryId, Category updatedCategory);
	}
}
