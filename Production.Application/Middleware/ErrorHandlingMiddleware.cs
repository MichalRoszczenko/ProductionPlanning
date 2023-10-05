using Microsoft.AspNetCore.Http;
using Production.Application.Exceptions;

namespace Production.Application.Middleware
{
	public sealed class ErrorHandlingMiddleware : IMiddleware
	{
		public async Task InvokeAsync(HttpContext context, RequestDelegate next)
		{
			try
			{
				await next.Invoke(context);
			}
			catch (ItemInUseException e)
			{
				context.Response.StatusCode = 409;
				await context.Response.WriteAsync(e.Message);
			}
			catch (Exception e)
			{
				context.Response.StatusCode = 500;
				await context.Response.WriteAsync("Something bad happened.");
			}

		}
	}
}
