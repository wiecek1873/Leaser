using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using RentalApp.Application.Interfaces;
using RentalApp.Domain.Interfaces;
using RentalApp.Domain.Entities;
using RentalApp.Application.Dto.Posts;
using RentalApp.Application.Exceptions;
using System.IO;
using System;

namespace RentalApp.Application.Services
{
	public class PostsService : IPostsService
	{
		private readonly IPostsRepository _postsRepository;
		private readonly IMapper _mapper;

		public PostsService(IPostsRepository postsRepository, IMapper mapper)
		{
			_postsRepository = postsRepository;
			_mapper = mapper;
		}

		public async Task<PostDto> GetPost(int postId)
		{
			var post = await _postsRepository.GetPost(postId);

			if (post == null)
				throw new NotFoundException("Post does not exist.");

			return _mapper.Map<PostDto>(post);
		}

		public async Task<PostDto> CreatePost(int categoryId, string userId, CreatePostDto newPostDto, CreatePostImageDto newPostImageDto)
		{

			/*
			 * 1. trzeba dodac tu walidacje czy id kategorii istnieje w bazie danych => categoryId
			 * 2. trzeba sprawdzić czy jesli int? ma wartosc w depositId czy taki depositId istnieje
			 * 
			 */
			byte[] postImage;

			if (newPostImageDto.PostImage == null || newPostImageDto.PostImage.Length == 0)
				throw new BadRequestException("You do not upload photo.");

			if (newPostImageDto.PostImage.ContentType.ToLower() != "image/jpeg" &&
				newPostImageDto.PostImage.ContentType.ToLower() != "image/jpg" &&
				newPostImageDto.PostImage.ContentType.ToLower() != "image/png")
				throw new BadRequestException("You do not upload photo.");


            /// tworzysz nowy post po co sprawdzasz jego id => do wywalenia on nie ma id => do wywalenia ten fragment
            //var post = await _postsRepository.GetPost(newPostDto.Id);

            //if (post != null)
            //	throw new ConflictException("Post with the same id already exist!");

            var newPost = _mapper.Map<Post>(newPostDto);
			// po mapowaniu mozesz juz przypisywac do dto zmienne ktore przesłałem a nie sa w tym dto i zrobieniu walidacji
			newPost.UserId = Guid.Parse(userId);
			newPost.CategoryId = categoryId;

			// Co to ma na celu? jesli chcesz zrobić walidacje lepiej zrobić to na początku wywołania metody i przenieść to co robiłem w kontrolerz tutaj na
			// poczatek jesli sprawdzisz ze przeslane dto nie jest nullem mozesz spokojnie mapowac //
			/*if (newPost == null)
				throw new ConflictException("Post creation failed! Please check post details and try again.");*/

			using (var memoryStream = new MemoryStream())
			{
				await newPostImageDto.PostImage.CopyToAsync(memoryStream);
				postImage = memoryStream.ToArray();
			}

			await _postsRepository.AddPost(newPost, postImage);

			// mapper nie da rady przemapowac zdjęcia, kóre jest tablicą bajtów na dto, dlatego trzeba napisac osobnego endpointa do pobrania zdjecia na podstawie id
			// dlatego stowrzyłeś sobie PostImageDto , które bedzie do frontu pobierać zdjecie
			return _mapper.Map<PostDto>(newPost);
		}
	}
}
