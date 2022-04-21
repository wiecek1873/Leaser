using System.Threading.Tasks;
using RentalApp.Application.Dto.Posts;

namespace RentalApp.Application.Interfaces
{
	public interface IPostsService
	{
		Task<PostDto> GetPost(int postId);
		Task<PostDto> CreatePost(int categoryId, string userId, CreatePostDto newPostDto, CreatePostImageDto newPostImageDto);
	}
}
