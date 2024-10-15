using Consultorio.Entities.DomainErrors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio.Models.Responses
{
    public class BaseResponse
    {
        public BaseResponse()
        {
        }

        public BaseResponse(bool success, Error error)
        {

            if(success && error != Error.None || !success && error == Error.None)
            {
                throw new ArgumentException("Invalid Error", nameof(error));
            } 

            Success = success;
            
            Error = error;
        }
        public BaseResponse(bool success)
        {
            Success = success;
        }
        public bool Success { get; set; }
        
        public Error Error { get; } = default!;

        public  BaseResponse IsSuccess() => new(success:true, Error.None);
        public  BaseResponse Failure(Error errorMessage) => new(success:false,error:errorMessage);
        

    }

}
