using RentalApp.Domain.Interfaces;
using RentalApp.Domain.Entities;
using System.Threading.Tasks;

namespace RentalApp.Infrastructure.Repositories
{
	class PostsRepository : IPostsRepository
	{
        //co zamiast UserManagera?
        //private readonly UserManager<User> _userManager;

        public PostsRepository(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public async Task<Post> GetPost(string postId)
        {
            var user = await _userManager.FindByIdAsync(postId);

            return user;
        }

        public async Task<Post> AddPost(Post newPost)
        {
            var result = await _userManager.CreateAsync(newUser, newUser.PasswordHash);

            if (!result.Succeeded)
                return null;

            return newPost;
        }
    }
}
