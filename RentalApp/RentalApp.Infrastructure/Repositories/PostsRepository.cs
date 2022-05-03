using RentalApp.Domain.Interfaces;
using RentalApp.Domain.Entities;
using System.Threading.Tasks;
using RentalApp.Infrastructure.Data;
using System.Linq;
using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace RentalApp.Infrastructure.Repositories
{
	public class PostsRepository : IPostsRepository
	{
		private readonly RentalAppContext _rentalAppContext;

		public PostsRepository(RentalAppContext rentalAppContext)
		{
			_rentalAppContext = rentalAppContext;
		}

		public async Task<Post> GetPost(int postId)
		{
			var post = await _rentalAppContext.Posts.SingleOrDefaultAsync(p => p.Id == postId);

			return post;
		}

		public async Task<List<Post>> GetPosts(Guid userId)
		{
			List<Post> posts = await _rentalAppContext.Posts.Where(p => p.UserId == userId).ToListAsync();

			//todo Nie wiem czy .Where zwróci je zawsze w tej samej kolejności dlatego dodałem sortowanie po id
			posts = posts.OrderByDescending(p => p.Id).ToList();

			return posts;
		}

		public async Task<Post> AddPost(Post newPost, byte[] postImage)
		{
			newPost.Image = postImage;

			await _rentalAppContext.Posts.AddAsync(newPost);
			await _rentalAppContext.SaveChangesAsync();

			return newPost;
		}

		public async Task UpdatePost(int postId, Post updatedPost, byte[] updatedPostImage)
		{
			var postToUpdate = await _rentalAppContext.Posts.SingleOrDefaultAsync(p => p.Id == postId);

			if(updatedPost != null)
			{
				postToUpdate.CategoryId = updatedPost.CategoryId;
				postToUpdate.UserId = updatedPost.UserId;
				postToUpdate.Title = updatedPost.Title;
				postToUpdate.Description = updatedPost.Description;
				postToUpdate.Image = updatedPostImage;
				postToUpdate.DepositId = updatedPost.DepositId;
				postToUpdate.Price = updatedPost.Price;
				postToUpdate.PricePerWeek = updatedPost.PricePerWeek;
				postToUpdate.PricePerMonth = updatedPost.PricePerMonth;
				postToUpdate.AvailableFrom = updatedPost.AvailableFrom;
				postToUpdate.AvailableTo = updatedPost.AvailableTo;
			}

			await _rentalAppContext.SaveChangesAsync();
		}

		public async Task DeletePost(int postId)
		{
			var postToDelete = await _rentalAppContext.Posts.SingleOrDefaultAsync(p => p.Id == postId);

			_rentalAppContext.Remove(postToDelete);

			await _rentalAppContext.SaveChangesAsync();
		}
	}
}
