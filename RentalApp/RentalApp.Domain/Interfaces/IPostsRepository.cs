using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using RentalApp.Domain.Entities;

namespace RentalApp.Domain.Interfaces
{
	public interface IPostsRepository
	{
		Task<Post> GetPost(int postId);

		Task<List<Post>> GetPosts();

		Task<List<Post>> GetPostsByCategory(int categoryId);

		Task<List<Post>> GetPostsByUserId(Guid userId);

		Task<Post> AddPost(Post newPost, byte[] postImage);

		Task UpdatePost(int postId, Post updatedPost, byte[] updatedPostImage);

		Task DeletePost(int postId);

		Task<List<Post>> GetPostsByPriceAscending(int categoryId);

		Task<List<Post>> GetPostsByPriceDescending(int categoryId);

		Task<List<Post>> GetPostsByPhrase(string phrase);
	}
}
