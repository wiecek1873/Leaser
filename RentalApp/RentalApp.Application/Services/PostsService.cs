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

namespace RentalApp.Application.Services
{
	public class PostsService : IPostsService
	{
		private readonly IPostsRepository _postsRepository;
		private readonly IMapper _mapper;

		public PostsService(IPostsRepository postsRepository, IMapper mapper)
		{
			_postsRepository = postsRepository;
			_mapper = mapper;
		}

		public async Task<PostDto> GetPost(int postId)
		{
			var post = await _postsRepository.GetPost(postId);

			if (post == null)
				throw new NotFoundException("Post does not exist.");

			return _mapper.Map<PostDto>(post);
		}

		public async Task<PostDto> CreatePost(CreatePostDto newPostDto, PostImageDto newPostImageDto)
		{
			byte[] postImage;

			if (newPostImageDto.PostImage == null || newPostImageDto.PostImage.Length == 0)
				throw new BadRequestException("You do not upload photo.");

			if (newPostImageDto.PostImage.ContentType.ToLower() != "image/jpeg" &&
				newPostImageDto.PostImage.ContentType.ToLower() != "image/jpg" &&
				newPostImageDto.PostImage.ContentType.ToLower() != "image/png")
				throw new BadRequestException("You do not upload photo.");

			var post = await _postsRepository.GetPost(newPostDto.Id);

			if (post != null)
				throw new ConflictException("Post with the same id already exist!");

			var newPost = _mapper.Map<Post>(newPostDto);

			if (newPost == null)
				throw new ConflictException("Post creation failed! Please check post details and try again.");

			using (var memoryStream = new MemoryStream())
			{
				await newPostImageDto.PostImage.CopyToAsync(memoryStream);
				postImage = memoryStream.ToArray();
			}

			await _postsRepository.AddPost(newPost, postImage);

			return _mapper.Map<PostDto>(newPost);
		}
	}
}
