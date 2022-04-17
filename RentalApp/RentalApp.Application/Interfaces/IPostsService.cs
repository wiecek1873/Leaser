using System.Threading.Tasks;
using RentalApp.Application.Dto.Posts;

namespace RentalApp.Application.Interfaces
{
	public interface IPostsService
	{
		Task<PostDto> GetPost(int postId);
		Task<PostDto> CreatePost(string userId, CreatePostDto newPostDto, CreatePostImageDto newPostImageDto);
	}
}
