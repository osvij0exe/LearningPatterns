using Consultorio.Models.Users;
using Consultorio.Services.Interfaces;
using ConsultorioSample.WebApiService.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ConsultorioSample.WebApiService.Controllers
{
    [ApiController]
    [Route("api/user")]
    public class UserController : ControllerBase
    {
        private readonly IUserServices _services;

        public UserController(IUserServices services)
        {
            _services = services;
        }


        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterUserDto registerUserDto)
        {
            var response = await _services.RegisterAsync(registerUserDto);

            return response.Success ? Ok(response) : response.ToProblemDetails();


        }


        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDtoRequest loginDtoRequest)
        {
            var response = await _services.LoginAsync(loginDtoRequest);

            return response.Success ? Ok(response) : response.ToProblemDetails();


        }
        [HttpPost("SendTokenToResetUserPassword")]
        public async Task<IActionResult> SendTokenToResetUserPassword(GenerateTokenToDtoRequest request)
        {
            var response = await _services.SendTokenToResetPasswordAsync(request);

            return response.Success ? Ok(response) : response.ToProblemDetails();
        }

        [HttpPost("ResetPassword")]
        public async Task<IActionResult> ResetPassword(ResetPasswordDtoRequest request)
        {
            var response = await _services.ResetPasswordAsync(request);

            return response.Success ? Ok(response) : response.ToProblemDetails();
        }

        // se requiere implementar servicio de correos si no no fucnionara
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> ChangPassword(ChangePasswordDtoRequest request)
        {
            // obtenemos el email del usuario authenticado
            var email = HttpContext.User.Claims.First(p => p.Type == ClaimTypes.Email).Value;

            var response = await _services.ChangePasswordAsync(email, request);

            return response.Success ? Ok(response) : response.ToProblemDetails();
        }


    }
}
