﻿using Consultorio.Models.Responses;
using Consultorio.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio.Services.Interfaces
{
    public interface IUserServices
    {
        Task<LoginDtoResposne> LoginAsync(LoginDtoRequest request);
        Task<BaseResponse> RegisterAsync(RegisterUserDto request);

        Task<BaseResponse> SendTokenToResetPasswordAsync(GenerateTokenToDtoRequest request);
        Task<BaseResponse> ResetPasswordAsync(ResetPasswordDtoRequest request);

        Task<BaseResponse> ChangePasswordAsync(string email, ChangePasswordDtoRequest request);

        Task<TwoFactorAuthenticationTokenDtoResponse> TwoFactorAuthenticationTokenAsync(GenerateTokenToDtoRequest request);
        Task<BaseResponse> EnableAuthenticatorAsync(EnableAuthenticatorCodeDtoRequest request);
        Task<BaseResponse> DesableTwoFactorAuthenticatorAsync(DesableTwoFactorAuthDtoRequest request);
    }
}
