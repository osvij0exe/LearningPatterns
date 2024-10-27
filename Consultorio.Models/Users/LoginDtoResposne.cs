using Consultorio.Entities.DomainErrors;
using Consultorio.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio.Models.Users
{
    public class LoginDtoResposne :BaseResponse
    {

        public LoginDtoResposne()
        {
            
        }

        public LoginDtoResposne(bool success,Error error)
            :base(success, error)
        {
            
        }
        public LoginDtoResposne(bool success,string givenName,string token)
            :base(success)
        {
            
        }

        public string GivenName { get; set; } = default!;
        public string Token { get; set; } = default!;


        public LoginDtoResposne IsSucess(bool success,string GivenName,string Toeken )
            => new(success: true,givenName:GivenName, token:Token);

        public LoginDtoResposne Failure(bool sucess, Error errorMessage)
            => new(success: false, error: errorMessage);

    }
}
