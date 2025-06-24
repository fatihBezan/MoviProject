

using Core.CrossCuttingConcerns.Exceptions.Types;

namespace Core.CrossCuttingConcerns.Exceptions.Handlers;

public abstract class ExceptionHandler
{
    public Task HandleExwceptionAsync(Exception exception)
    {
       return exception switch
        {
            BusinessException businessException => HandleExceptionAsync(businessException),
            NotFoundException notFoundException => HandleExceptionAsync(notFoundException),
           => HandleExceptionAsync(exception)
        };
    }

    protected abstract Task HandleExceptionAsync(NotFoundException notFoundException);
    protected abstract Task HandleExceptionAsync(BusinessException businessException);
    protected abstract Task HandleExceptionAsync(Exception exception);

}
