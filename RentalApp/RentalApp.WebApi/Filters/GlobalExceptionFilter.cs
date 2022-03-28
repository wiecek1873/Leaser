using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using RentalApp.Application.Exceptions;

namespace RentalApp.WebApi.Filters
{
    public class GlobalExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            var response = new ContentResult();

            response.Content = context.Exception.Message;
            response.StatusCode = 500;
            response.ContentType = "text/plain";

            if (context.Exception is BadRequestException)
            {
                response.Content = context.Exception.Message;
                response.StatusCode = 400;
            }
            if(context.Exception is UnauthorizedException)
            {
                response.Content = context.Exception.Message;
                response.StatusCode = 401;
            }
            if (context.Exception is ForbiddenException)
            {
                response.Content = context.Exception.Message;
                response.StatusCode = 403;
            }
            if (context.Exception is NotFoundException)
            {
                response.Content = context.Exception.Message;
                response.StatusCode = 404;
            }
            if (context.Exception is MethodNotAllowedException)
            {
                response.Content = context.Exception.Message;
                response.StatusCode = 405;
            }
            if (context.Exception is ConflictException)
            {
                response.Content = context.Exception.Message;
                response.StatusCode = 409;
            }

            context.Result = response;
            base.OnException(context);
        }
    }
}
