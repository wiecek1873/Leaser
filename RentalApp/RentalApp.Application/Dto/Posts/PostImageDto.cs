using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace RentalApp.Application.Dto.Posts
{
	public class PostImageDto
	{
		public IFormFile PostImage { get; set; }
	}
}
