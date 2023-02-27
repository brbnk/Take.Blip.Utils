using System.Net;

namespace Take.Blip.Utils.Api.Middlewares;

public sealed class ExceptionHandlerMiddleware
{
  private readonly RequestDelegate _next;

  public ExceptionHandlerMiddleware(RequestDelegate next)
  {
    _next = next;
  }

  public async Task InvokeAsync(HttpContext context)
  {
    try 
    {
      await _next(context);
    }
    catch(Exception ex)
    {
      context.Response.StatusCode = (int) HttpStatusCode.InternalServerError;
      await context.Response.WriteAsync(ex.Message);
    }
  }
}

public static class ExceptionHandlerMiddlewareExtensions
{
  public static IApplicationBuilder UseExceptionHandlerMiddleware(
    this IApplicationBuilder builder)
  {
    return builder.UseMiddleware<ExceptionHandlerMiddleware>();  
  }
}