 using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace RentalApp.Application.Dto.Posts
{
	public class CreatePostImageDto
	{
		[Required(ErrorMessage = "Image is required!")]
		public IFormFile PostImage { get; set; }
	}
}
