using System.Threading.Tasks;
using RentalApp.Domain.Entities;

namespace RentalApp.Domain.Interfaces
{
	public interface IPostsRepository
	{
		Task<Post> GetPost(string postId);
		Task<Post> AddPost(Post newPost);
	}
}
