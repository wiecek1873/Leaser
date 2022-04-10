using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using RentalApp.Application.Interfaces;
using RentalApp.Domain.Interfaces;
using RentalApp.Domain.Entities;
using RentalApp.Application.Dto.Posts;
using RentalApp.Application.Exceptions;

namespace RentalApp.Application.Services
{
	class PostsService : IPostsService
	{
        private readonly IPostsRepository _postsRepository;
        private readonly IMapper _mapper;

        public PostsService(IPostsRepository postsRepository, UserManager<User> userManager, IMapper mapper)
        {
            _postsRepository = postsRepository;
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<PostDto> GetPost(string postId)
        {
            var post = await _postsRepository.GetPost(postId);

            if (post == null)
                throw new NotFoundException("Post does not exist.");

            return _mapper.Map<PostDto>(post);
        }

        public async Task<PostDto> CreatePost(CreatePostDto newPostDto)
        {
            var user = await _userManager.FindByEmailAsync(newPostDto.Email);

            if (user != null)
                throw new ConflictException("User with the same email already exists!");

            var newPost = _mapper.Map<User>(newPostDto);

            if (newPost == null)
                throw new ConflictException("User creation failed! Please check user details and try again.");

            await _postsRepository.AddPost(newPost);

            return _mapper.Map<PostDto>(newPost);
        }
}
