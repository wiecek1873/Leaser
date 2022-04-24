using Microsoft.AspNetCore.Http;

namespace RentalApp.Application.Dto.Posts
{
	public class PostImageDto
	{
		public IFormFile PostImage { get; set; }
	}
}
