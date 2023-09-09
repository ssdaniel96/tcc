using Application.Shared.Dtos;
using Domain.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Api.Infrastructure.Filters;

public class ExceptionFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        if (context.Exception is BaseException @baseException)
        {
            var result = new ResponseDto(baseException);

            context.Result = new BadRequestObjectResult(result);
        }
        else
        {
            var result = new ResponseDto()
            {
                IsSuccessfully = false,
                Error = "Ocorreu um erro interno"
            };

            context.Result = new ObjectResult(result)
            {
                StatusCode = 500
            };
        }
    }
}