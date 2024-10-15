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
                Title = "Not Found",
                Status = StatusCodes.Status400BadRequest,
                Type = "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.1",

            };
            /*
             Investigar la diferencia entre utilizar un diccionario de array o un diccionario de listas
             */

            //problemDetails.Extensions.Add("errors", new[] {response.Error});
            problemDetails.Extensions.Add("errors", new List<Error>() { response.Error});

            return new ObjectResult(problemDetails);
        }
    }
}
