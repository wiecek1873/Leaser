using AutoMapper;
using System.Threading.Tasks;
using RentalApp.Application.Exceptions;
using RentalApp.Application.Dto.Categories;
using RentalApp.Application.Interfaces;
using RentalApp.Domain.Interfaces;
using RentalApp.Domain.Entities;


namespace RentalApp.Application.Services
{
	public class CategoriesService : ICategoriesService
	{
		private readonly ICategoriesRepository _categoriesRepository;
		private readonly IMapper _mapper;

		public CategoriesService(ICategoriesRepository categoriesRepository, IMapper mapper)
		{
			_categoriesRepository= categoriesRepository;
			_mapper = mapper;
		}

		public async Task<CategoryDto> GetCategory(int categoryId)
		{
			var category = await _categoriesRepository.GetCategory(categoryId);

			if (category == null)
				throw new NotFoundException("Category with this id does not exist.");

			return _mapper.Map<CategoryDto>(category);
		}

		public async Task<CategoryDto> CreateCategory(RequestCategoryDto newCategoryDto)
		{
			var categoryToAdd = _mapper.Map<Category>(newCategoryDto);

			await _categoriesRepository.AddCategory(categoryToAdd);

			return _mapper.Map<CategoryDto>(categoryToAdd);
		}

		public async Task UpdateCategory(int categoryId, RequestCategoryDto updatedCategoryDto)
		{
			var categoryToUpdate = await _categoriesRepository.GetCategory(categoryId);

			if (categoryToUpdate == null)
				throw new NotFoundException("Category with this id does not exist.");

			categoryToUpdate = _mapper.Map<Category>(updatedCategoryDto);

			await _categoriesRepository.UpdateCategory(categoryId, categoryToUpdate);
		}

		public async Task DeleteCategory(int categoryId)
		{
			var categoryToDelete = await _categoriesRepository.GetCategory(categoryId);

			if (categoryToDelete == null)
				throw new NotFoundException("Category with this id does not exist.");

			await _categoriesRepository.DeleteCategory(categoryId);
		}
	}
}
