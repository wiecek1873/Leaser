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
using Microsoft.AspNetCore.Http;

namespace RentalApp.Application.Services
{
	public class PostsService : IPostsService
	{
		private readonly IPostsRepository _postsRepository;
		private readonly ICategoriesRepository _categoriesRepository;
		private readonly IUsersRepository _usersRepository;
		private readonly IMapper _mapper;

		public PostsService(IPostsRepository postsRepository, ICategoriesRepository categoriesRepository, IUsersRepository usersRepository, IMapper mapper)
		{
			_postsRepository = postsRepository;
			_categoriesRepository = categoriesRepository;
			_usersRepository = usersRepository;
			_mapper = mapper;
		}

		public async Task<PostDto> GetPost(int postId)
		{
			var post = await _postsRepository.GetPost(postId);

			if (post == null)
				throw new NotFoundException("Post does not exist.");

			return _mapper.Map<PostDto>(post);
		}

		public async Task<PostImageDto> GetPostImage(int postId)
		{
			var post = await _postsRepository.GetPost(postId);

			if (post == null)
				throw new NotFoundException("Post does not exist");

			return new PostImageDto { PostImage = post.Image };
		}

		public async Task<List<PostDto>> GetPostsByCategory(int categoryId)
		{
			var category = await _categoriesRepository.GetCategory(categoryId);

			if (category == null)
				throw new BadRequestException("Category with this id does not exist.");

			var posts = await _postsRepository.GetPostsByCategory(categoryId);

			return _mapper.Map<List<PostDto>>(posts);
		}

		public async Task<List<PostDto>> GetPostsByUserId(string userId)
		{
			var user = await _usersRepository.GetUser(userId);

			if (user == null)
				throw new NotFoundException("User with this id does not exist");

			if (!Guid.TryParse(userId, out var userGuid))
				throw new BadRequestException("User id should contain 32 digits with 4 dashes (xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx).");

			var posts = await _postsRepository.GetPostsByUserId(userGuid);

			return _mapper.Map<List<PostDto>>(posts);
		}

		public async Task<PostDto> CreatePost(int categoryId, string userId, RequestPostDto newPostDto, RequestPostImageDto newPostImageDto)
		{
			byte[] postImage;

			if (newPostImageDto.PostImage == null || newPostImageDto.PostImage.Length == 0)
				throw new BadRequestException("You do not upload photo.");

			if (newPostImageDto.PostImage.ContentType.ToLower() != "image/jpeg" &&
				newPostImageDto.PostImage.ContentType.ToLower() != "image/jpg" &&
				newPostImageDto.PostImage.ContentType.ToLower() != "image/png")
				throw new BadRequestException("You do not upload photo.");

			var category = await _categoriesRepository.GetCategory(categoryId);
			if (category == null)
				throw new BadRequestException("Category does not exist.");

			var newPost = _mapper.Map<Post>(newPostDto);
			newPost.UserId = Guid.Parse(userId);
			newPost.CategoryId = categoryId;

			using (var memoryStream = new MemoryStream())
			{
				await newPostImageDto.PostImage.CopyToAsync(memoryStream);
				postImage = memoryStream.ToArray();
			}

			await _postsRepository.AddPost(newPost, postImage);

			return _mapper.Map<PostDto>(newPost);
		}

		public async Task UpdatePost(int postId, int categoryId, string userId, RequestPostDto updatedPostDto, RequestPostImageDto updatedPostImageDto)
		{
			byte[] postImage;

			if (updatedPostImageDto.PostImage == null || updatedPostImageDto.PostImage.Length == 0)
				throw new BadRequestException("You do not upload photo.");

			if (updatedPostImageDto.PostImage.ContentType.ToLower() != "image/jpeg" &&
				updatedPostImageDto.PostImage.ContentType.ToLower() != "image/jpg" &&
				updatedPostImageDto.PostImage.ContentType.ToLower() != "image/png")
				throw new BadRequestException("You do not upload photo.");

			if (await _categoriesRepository.GetCategory(categoryId) == null)
				throw new BadRequestException("Category does not exist.");


			var postToUpdate = await _postsRepository.GetPost(postId);

			if (postToUpdate == null)
				throw new NotFoundException("Post with this id does not exist.");

			if (postToUpdate.UserId != Guid.Parse(userId))
				throw new MethodNotAllowedException("This user can't edit other user posts.");

			postToUpdate = _mapper.Map<Post>(updatedPostDto);
			postToUpdate.UserId = Guid.Parse(userId);
			postToUpdate.CategoryId = categoryId;

			using (var memoryStream = new MemoryStream())
			{
				await updatedPostImageDto.PostImage.CopyToAsync(memoryStream);
				postImage = memoryStream.ToArray();
			}

			await _postsRepository.UpdatePost(postId, postToUpdate, postImage);
		}

		public async Task DeletePost(int postId, string userId)
		{
			var postToDelete = await _postsRepository.GetPost(postId);

			if (postToDelete == null)
				throw new NotFoundException("Post with this id does not exist.");

			if (postToDelete.UserId != Guid.Parse(userId))
				throw new MethodNotAllowedException("This user can't delete other user posts.");

			await _postsRepository.DeletePost(postId);
		}

		public async Task<List<PostDto>> GetPostsByPriceAscending(int categoryId)
		{
			var category = await _categoriesRepository.GetCategory(categoryId);

			if (category == null)
				throw new BadRequestException("Category with this id does not exist.");

			var posts = await _postsRepository.GetPostsByPriceAscending(categoryId);

			return _mapper.Map<List<PostDto>>(posts);
		}

		public async Task<List<PostDto>> GetPostsByPriceDescending(int categoryId)
		{
			var category = await _categoriesRepository.GetCategory(categoryId);

			if (category == null)
				throw new BadRequestException("Category with this id does not exist.");

			var posts = await _postsRepository.GetPostsByPriceDescending(categoryId);

			return _mapper.Map<List<PostDto>>(posts);
		}
	}
}
