﻿using System.Threading.Tasks;
using RentalApp.Application.Dto.Posts;

namespace RentalApp.Application.Interfaces
{
	public interface IPostsService
	{
		Task<PostDto> GetPost(string postId);
		Task<PostDto> CreatePost(CreatePostDto newPostDto);
	}
}
