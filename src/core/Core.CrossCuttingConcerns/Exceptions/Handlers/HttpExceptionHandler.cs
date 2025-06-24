
using Core.CrossCuttingConcerns.Exceptions.Extensions;
using Core.CrossCuttingConcerns.Exceptions.HttpProblemDetails;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Microsoft.AspNetCore.Http;
using System.Security.AccessControl;
using System.Text.Json;

namespace Core.CrossCuttingConcerns.Exceptions.Handlers;

public sealed class HttpExceptionHandler : ExceptionHandler
{
   private HttpResponse  response;

    public HttpResponse Response {
        get => response ?? throw new ArgumentNullException(nameof(response)) ;
        set =>response=value;
    }

    protected override Task HandleExceptionAsync(NotFoundException notFoundException)
    {
       Response.StatusCode = StatusCodes.Status404NotFound;
        NotFoundProblemDetails problem = new NotFoundProblemDetails(notFoundException.Message);
      
        string details = JsonSerializer.Serialize(problem);
        return response.WriteAsync(details);
    }

    protected override Task HandleExceptionAsync(BusinessException businessException)
    {
        Response.StatusCode = StatusCodes.Status400BadRequest;
        string details = new BusinessProblemDetails(businessException.Message).AsJson();
        return Response.WriteAsync(details);
    }

    protected override Task HandleExceptionAsync(Exception exception)
    {
        Response.StatusCode = StatusCodes.Status500InternalServerError;
        string details = new ServerErrorProblemDetails().AsJson();
        return Response.WriteAsync(details);
    }
}
