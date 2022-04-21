 using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace RentalApp.Application.Dto.Posts
{
	public class RequestPostImageDto
	{
		[Required(ErrorMessage = "Image is required!")]
		public IFormFile PostImage { get; set; }
	}
}
