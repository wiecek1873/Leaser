using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using RentalApp.Domain.Entities;
using RentalApp.Domain.Interfaces;
using RentalApp.Infrastructure.Data;

namespace RentalApp.Infrastructure.Repositories
{
	public class CategoriesRepository : ICategoriesRepository
	{
        private readonly RentalAppContext _rentalAppContext;

        public CategoriesRepository(RentalAppContext rentalAppContext)
        {
            _rentalAppContext = rentalAppContext;
        }

		public async Task<List<Category>> GetCategories()
		{
			var categories = await _rentalAppContext.Categories.ToListAsync();

			return categories;
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

			if (categoryToUpdate != null)
			{
				categoryToUpdate.CategoryName = updatedCategory.CategoryName;
				categoryToUpdate.ImageURL = updatedCategory.ImageURL;
			}

			await _rentalAppContext.SaveChangesAsync();
		}

		public async Task DeleteCategory(int categoryId)
		{
			var categoryToDelete = await _rentalAppContext.Categories.SingleOrDefaultAsync(c => c.Id == categoryId);

			if (categoryToDelete != null)
				_rentalAppContext.Categories.Remove(categoryToDelete);

			await _rentalAppContext.SaveChangesAsync();
		}
	}
}
