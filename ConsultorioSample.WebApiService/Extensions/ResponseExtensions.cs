using Consultorio.Entities.DomainErrors;
using Consultorio.Models.Responses;
using Microsoft.AspNetCore.Mvc;

namespace ConsultorioSample.WebApiService.Extensions
{
    public static class ResponseExtensions
    {
        public static ObjectResult ToProblemDetails(this BaseResponse response)
        {
            if (response.Success)
            {
                throw new InvalidOperationException("Can't convert success re");
            }

            var problemDetails = new ProblemDetails()
            {
                Title = GetTitle(response.Error.ErrorType),
                Status = GetStatusCode(response.Error.ErrorType),
                Type = GetType(response.Error.ErrorType),

            };
            /*
             Investigar la diferencia entre utilizar un diccionario de array o un diccionario de listas
             */

            //problemDetails.Extensions.Add("errors", new[] {response.Error});
            problemDetails.Extensions.Add("errors", new List<Error>() { response.Error});

            return new ObjectResult(problemDetails);
        }


        public static int GetStatusCode(ErrorType errorType)
        {
            return errorType switch
            {
                ErrorType.Validation => StatusCodes.Status400BadRequest,
                ErrorType.NotFound => StatusCodes.Status404NotFound,
                ErrorType.Conflict => StatusCodes.Status409Conflict,
                ErrorType.Exception => StatusCodes.Status500InternalServerError,
                _ => StatusCodes.Status500InternalServerError,
            };
        }


        public static string GetTitle(ErrorType errorType)
        {
            return errorType switch
            {
                ErrorType.Validation => "Bad Request",
                ErrorType.NotFound => "Not Found",
                ErrorType.Conflict => "Conflict",
                ErrorType.Exception => "Internal Server Error",
                _ => "Internal Server Error",
            };
        }

        public static string GetType(ErrorType errorType) =>// este metodo ya tiene implicito el return
             errorType switch
             {
                 ErrorType.Validation => "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.1",
                 ErrorType.NotFound => "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.4",
                 ErrorType.Conflict => "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.8",
                 ErrorType.Exception => "https://datatracker.ietf.org/doc/html/rfc7231#section-6.6.1",
                 _ => "https://datatracker.ietf.org/doc/html/rfc7231#section-6.6.1",
             };

    }
}
