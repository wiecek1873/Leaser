using RentalApp.Domain.Interfaces;
using RentalApp.Domain.Entities;
using System.Threading.Tasks;
using RentalApp.Infrastructure.Data;

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
			var post = await _rentalAppContext.FindAsync<Post>(postId);

			return post;
		}

		public async Task<Post> AddPost(Post newPost)
		{
			await _rentalAppContext.AddAsync(newPost);
			await _rentalAppContext.SaveChangesAsync();

			return newPost;
		}
	}
}
