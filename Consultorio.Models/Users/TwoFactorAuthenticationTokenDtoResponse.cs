using Consultorio.Entities.DomainErrors;
using Consultorio.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio.Models.Users
{
    public class TwoFactorAuthenticationTokenDtoResponse : BaseResponse
    {
        public TwoFactorAuthenticationTokenDtoResponse()
        {
            
        }

        public TwoFactorAuthenticationTokenDtoResponse(bool success, Error error)
            :base(success, error)
        {
            
        }

        public TwoFactorAuthenticationTokenDtoResponse(bool success, string token)
            :base(success)
        {
            
        }
        public string Token { get; set; } = default!;


        public TwoFactorAuthenticationTokenDtoResponse IsSuccess(bool success, string token)
            => new(success: true, token: Token);

        public TwoFactorAuthenticationTokenDtoResponse Failure(bool success,Error errorMessage)
            => new(success:false,error:errorMessage);

    }
}
