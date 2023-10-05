using Microsoft.AspNetCore.Http;

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
			catch (Exception e)
			{
				context.Response.StatusCode = 500;
				await context.Response.WriteAsync("Something bad happened.");
			}
		}
	}
}
