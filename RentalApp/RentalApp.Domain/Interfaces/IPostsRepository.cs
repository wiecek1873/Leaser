using System.Threading.Tasks;
using RentalApp.Domain.Entities;

namespace RentalApp.Domain.Interfaces
{
	public interface IPostsRepository
	{
		Task<Post> GetPost(int postId);
		Task<Post> AddPost(Post newPost, byte[] postImage);
		Task UpdatePost(int postId, Post updatedPost);
		Task DeletePost(int postId);
	}
}
