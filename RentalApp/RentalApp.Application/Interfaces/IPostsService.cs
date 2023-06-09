﻿using System.Collections.Generic;
using System.Threading.Tasks;
using RentalApp.Application.Dto.Posts;

namespace RentalApp.Application.Interfaces
{
	public interface IPostsService
	{
		Task<PostDto> GetPost(int postId);

		Task<List<PostDto>> GetPosts();

		Task<PostImageDto> GetPostImage(int postId);

		Task<List<PostDto>> GetPostsByCategory(int categoryId);

		Task<List<PostDto>> GetPostsByUserId(string userId);

		Task<PostDto> CreatePost(int categoryId, string userId, RequestPostDto newPostDto, RequestPostImageDto newPostImageDto);

		Task UpdatePost(int postId, int categoryId, string userId, RequestPostDto updatedPostDto, RequestPostImageDto updatedPostImageDto);

		Task DeletePost(int postId, string userId);

		Task<List<PostDto>> GetPostsByPriceAscending(int categoryId);

		Task<List<PostDto>> GetPostsByPriceDescending(int categoryId);

		Task<List<PostDto>> GetPostsByPhrase(string phrase);
	}
}
