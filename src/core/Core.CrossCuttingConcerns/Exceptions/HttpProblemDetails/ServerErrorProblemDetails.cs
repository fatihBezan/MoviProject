

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Core.CrossCuttingConcerns.Exceptions.HttpProblemDetails;

public sealed class ServerErrorProblemDetails: ProblemDetails
{
    public ServerErrorProblemDetails()
    {
        Title = "Internal Server Error";
        Detail= "Internal Server Error";
        Status = StatusCodes.Status500InternalServerError;
        Type = "https://example.com/problems/InternalServerError";
    }
   
   
}
