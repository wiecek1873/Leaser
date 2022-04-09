using System.Linq;
using System.Security.Claims;


namespace RentalApp.WebApi.Extensions
{
    public static class UserExtension
    {
        public static string GetId(this ClaimsPrincipal user)
        {
            var id = user.Claims
                .Single(c => c.Type == ClaimTypes.NameIdentifier)
                .Value;

            return id;
        }
    }
}
