using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using RentalApp.Domain.Entities;

namespace RentalApp.Domain.Interfaces
{
	public interface IPostsRepository
	{
		Task<Post> GetPost(int postId);

		Task<List<Post>> GetPosts(Guid userId);

		Task<Post> AddPost(Post newPost, byte[] postImage);

		Task UpdatePost(int postId, Post updatedPost, byte[] updatedPostImage);

		Task DeletePost(int postId);
	}
}
