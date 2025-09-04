using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using subtask.DTOs;
using System;
using System.Diagnostics;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace subtask.Exceptions;

public sealed class GlobalExceptionHandler : IExceptionHandler
{
  private readonly ILogger<GlobalExceptionHandler> _logger;

  public GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger)
  {
    _logger = logger;
  }
  public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
  {
    _logger.LogError(exception, "An error ocurred: {Message}", exception.Message);
    httpContext.Response.ContentType = "application/json";
    httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
    var result = new ApiResponse<string>
    {
      Success = false,
      Error = exception.GetType().ToString(),
      Message = exception.Message
    };

    await httpContext.Response.WriteAsJsonAsync(result, cancellationToken);
    return true;
  }
}