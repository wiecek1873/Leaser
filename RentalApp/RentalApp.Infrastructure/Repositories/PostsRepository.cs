using RentalApp.Domain.Interfaces;
using RentalApp.Domain.Entities;
using System.Threading.Tasks;
using RentalApp.Infrastructure.Data;
using System.Linq;
using Microsoft.EntityFrameworkCore;

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

		public async Task<Post> AddPost(Post newPost)
		{
			await _rentalAppContext.Posts.AddAsync(newPost);
			await _rentalAppContext.SaveChangesAsync();

			return newPost;
		}
	}
}
