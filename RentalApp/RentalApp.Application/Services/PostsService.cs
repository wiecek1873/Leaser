using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using RentalApp.Application.Interfaces;
using RentalApp.Domain.Interfaces;
using RentalApp.Domain.Entities;
using RentalApp.Application.Dto.Posts;
using RentalApp.Application.Exceptions;
using System.IO;
using System;

namespace RentalApp.Application.Services
{
	public class PostsService : IPostsService
	{
		private readonly IPostsRepository _postsRepository;
		private readonly ICategoriesRepository _categoriesRepository;
		private readonly IDepositsRepository _depositsRepository;
		private readonly IMapper _mapper;

		public PostsService(IPostsRepository postsRepository, ICategoriesRepository categoriesRepository, IMapper mapper)
		{
			_postsRepository = postsRepository;
			_categoriesRepository = categoriesRepository;
			_mapper = mapper;
		}

		public async Task<PostDto> GetPost(int postId)
		{
			var post = await _postsRepository.GetPost(postId);

			if (post == null)
				throw new NotFoundException("Post does not exist.");

			return _mapper.Map<PostDto>(post);
		}

		public async Task<PostDto> CreatePost(int categoryId, string userId, CreatePostDto newPostDto, CreatePostImageDto newPostImageDto)
		{
			byte[] postImage;

			if (newPostImageDto.PostImage == null || newPostImageDto.PostImage.Length == 0)
				throw new BadRequestException("You do not upload photo.");

			if (newPostImageDto.PostImage.ContentType.ToLower() != "image/jpeg" &&
				newPostImageDto.PostImage.ContentType.ToLower() != "image/jpg" &&
				newPostImageDto.PostImage.ContentType.ToLower() != "image/png")
				throw new BadRequestException("You do not upload photo.");

			if (_categoriesRepository.GetCategory(categoryId) == null)
				throw new BadRequestException("Category does not exist.");

			if (newPostDto.DepositId.HasValue && _depositsRepository.GetDeposit(newPostDto.DepositId.Value) == null)
				throw new BadRequestException("Deposit does not exist.");

			var newPost = _mapper.Map<Post>(newPostDto);
			// po mapowaniu mozesz juz przypisywac do dto zmienne ktore przesłałem a nie sa w tym dto i zrobieniu walidacji
			newPost.UserId = Guid.Parse(userId);
			newPost.CategoryId = categoryId;

			using (var memoryStream = new MemoryStream())
			{
				await newPostImageDto.PostImage.CopyToAsync(memoryStream);
				postImage = memoryStream.ToArray();
			}

			await _postsRepository.AddPost(newPost, postImage);

			// mapper nie da rady przemapowac zdjęcia, kóre jest tablicą bajtów na dto, dlatego trzeba napisac osobnego endpointa do pobrania zdjecia na podstawie id
			// dlatego stowrzyłeś sobie PostImageDto , które bedzie do frontu pobierać zdjecie
			return _mapper.Map<PostDto>(newPost);
		}
	}
}
