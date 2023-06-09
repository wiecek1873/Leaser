﻿using RentalApp.Domain.Interfaces;
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

		public async Task<List<Post>> GetPosts()
        {
			var posts = await _rentalAppContext.Posts.ToListAsync();

			return posts;
		}

		public async Task<List<Post>> GetPostsByCategory(int categoryId)
		{
			List<Post> posts = await _rentalAppContext.Posts.Where(p => p.CategoryId == categoryId)
				.OrderByDescending(p => p.Id).ToListAsync();

			return posts;
		}

		public async Task<List<Post>> GetPostsByUserId(Guid userId)
		{
			List<Post> posts = await _rentalAppContext.Posts.Where(p => p.UserId == userId)
				.OrderByDescending(p => p.Id).ToListAsync();

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
				postToUpdate.Price = updatedPost.Price;
				postToUpdate.DepositValue = updatedPost.DepositValue;
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

        public async Task<List<Post>> GetPostsByPriceAscending(int categoryId)
        {
			List<Post> posts = await _rentalAppContext.Posts.Where(p => p.CategoryId == categoryId).OrderBy(p => p.Price).ToListAsync();

			return posts;
		}

		public async Task<List<Post>> GetPostsByPriceDescending(int categoryId)
		{
			List<Post> posts = await _rentalAppContext.Posts.Where(p => p.CategoryId == categoryId).OrderByDescending(p => p.Price).ToListAsync();

			return posts;
		}

		public async Task<List<Post>> GetPostsByPhrase(string phrase)
		{
			List<Post> posts = await _rentalAppContext.Posts.Where(p => p.Title.Contains(phrase) || p.Description.Contains(phrase))
				.OrderByDescending(p => p.Price)
				.ToListAsync();

			return posts;
		}
	}
}
