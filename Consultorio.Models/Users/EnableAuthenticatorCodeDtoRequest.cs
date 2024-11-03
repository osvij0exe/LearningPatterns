using Consultorio.Entities.DomainErrors;
using Consultorio.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio.Models.Users
{
    public class EnableAuthenticatorCodeDtoRequest: BaseResponse
    {
        public EnableAuthenticatorCodeDtoRequest()
        {
            
        }

        public EnableAuthenticatorCodeDtoRequest(bool success, Error error)
            :base(success, error)
        {
            
        }

        public EnableAuthenticatorCodeDtoRequest(bool success,string codeProvided)
            :base(success)
        {
            
        }


        public string CodeProvided { get; set; } = default!;
        public string Usuario { get; set; } = default!;
        public string Email { get; set; } = default!;

        public EnableAuthenticatorCodeDtoRequest IsSuccess(bool success, string code)
            => new(success: true, codeProvided: CodeProvided);

        public EnableAuthenticatorCodeDtoRequest Failure(bool success, Error errorMessage)
            => new(success: false,error:errorMessage);


    }
}
