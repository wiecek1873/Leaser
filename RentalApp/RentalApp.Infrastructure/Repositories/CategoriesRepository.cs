using Microsoft.EntityFrameworkCore;
using RentalApp.Domain.Entities;
using RentalApp.Domain.Interfaces;
using RentalApp.Infrastructure.Data;
using System.Threading.Tasks;

namespace RentalApp.Infrastructure.Repositories
{
	public class CategoriesRepository : ICategoriesRepository
	{
        private readonly RentalAppContext _rentalAppContext;

        public CategoriesRepository(RentalAppContext rentalAppContext)
        {
            _rentalAppContext = rentalAppContext;
        }

		public async Task<Category> GetCategory(int categoryId)
		{
			var category = await _rentalAppContext.Categories.SingleOrDefaultAsync(c => c.Id == categoryId);
			
			return category;
		}

		public async Task<Category> AddCategory(Category newCategory)
		{
			_rentalAppContext.Categories.Add(newCategory);
			await _rentalAppContext.SaveChangesAsync();

			return newCategory;
		}

		public async Task UpdateCategory(int categoryId, Category updatedCategory)
		{
			var categoryToUpdate = await _rentalAppContext.Categories.SingleOrDefaultAsync(c => c.Id == categoryId);

			if(categoryToUpdate != null)
			{
				categoryToUpdate.CategoryName = updatedCategory.CategoryName;
				categoryToUpdate.Posts = updatedCategory.Posts;
			}

			await _rentalAppContext.SaveChangesAsync();
		}
	}
}
