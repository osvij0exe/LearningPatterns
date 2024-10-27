using Consultorio.DataAccess.Users;
using Consultorio.Entities.DomainErrors;
using Consultorio.Entities.Security;
using Consultorio.Models;
using Consultorio.Models.Responses;
using Consultorio.Models.Users;
using Consultorio.Repository.Errors;
using Consultorio.Repository.Interfaces;
using Consultorio.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Consultorio.Services.Implementation
{
    public class UserServices : IUserServices
    {
        private readonly UserManager<ConsultorioUser> _userManager;
        private readonly ILogger<UserServices> _logger;
        private readonly IOptions<Appsettings> _options;
        private readonly IEmailServices _emailServices;

        public UserServices(UserManager<ConsultorioUser> userManager,
            ILogger<UserServices> logger,
            IOptions<Appsettings> options, 
            IEmailServices emailServices)
        {
            _userManager = userManager;
            _logger = logger;
            _options = options;
            _emailServices = emailServices;
        }

        //se requiere implementacion de correos
        public async Task<BaseResponse> ChangePasswordAsync(string email, ChangePasswordDtoRequest request)
        {
            var response = new BaseResponse();
            try
            {
                var user = await _userManager.FindByEmailAsync(email);
                if (user is null)
                {
                    return response.Failure(UserErrors.NotFound(email));
                }
                var result = await _userManager.ChangePasswordAsync(user, request.CurrentPassword, request.NewPassword);
                if (!result.Succeeded)
                {
                    var sb = new StringBuilder();
                    foreach (var identityError in result.Errors)
                    {
                        sb.AppendFormat("{0}", identityError.Description);
                    }
                    //sb.Clear();
                    return response.Failure(errorMessage: Error.NotFound(code: "user.Validation Error", description: sb.ToString()));
                }
                else
                {
                    //TODO se envia un email con la confiramcion de que se cambio el password exitosamente"
                    await _emailServices.SendEmailAsync(email, "Imss - Cambio de password succeeded", $"{email} Your password was reset succeeded");
                }
                response.IsSuccess(succes: response.Success = true);


            }
            catch (Exception ex)
            {

                string ErrorMessage = "An error ocurred while trying to change the password";
                _logger.LogCritical(ex, "{ErrorMessage}{Message}", ErrorMessage, ex.Message);
            }
            return response;
        }

        public async Task<LoginDtoResposne> LoginAsync(LoginDtoRequest request)
        {
            var response = new LoginDtoResposne();
            try
            {
                var identtiy = await _userManager.FindByEmailAsync(request.Email);

                if (identtiy is null)
                    return response.Failure(sucess:false, errorMessage: UserErrors.BadRequest());
                if(await _userManager.IsLockedOutAsync(identtiy))
                {
                    return response.Failure(sucess: false, UserErrors.UserLoked(request.Email));
                }
                if(!await _userManager.CheckPasswordAsync(identtiy, request.Password))
                {
                    
                    await _userManager.AccessFailedAsync(identtiy);
                    return response.Failure(sucess: false, UserErrors.Accessfailed(request.Email));
                }
                var roles = await _userManager.GetRolesAsync(identtiy);
                var fechaExpiracion = DateTime.Now.AddDays(1);

                //creating claims
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, identtiy.GivenName),
                    new Claim(ClaimTypes.Email, identtiy.Email!),
                    new Claim(ClaimTypes.Expiration, fechaExpiracion.ToLongDateString()),
                };
                claims.AddRange(roles.Select(x => new Claim(ClaimTypes.Role, x)));

                //Creamos el JWT
                var llaversimetrica = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_options.Value.Jwt.SecretKey));
                var credenciales = new SigningCredentials(llaversimetrica,SecurityAlgorithms.HmacSha256);

                var header = new JwtHeader(credenciales);

                var payload = new JwtPayload(
                    issuer:_options.Value.Jwt.Emisor,
                    audience:_options.Value.Jwt.Emisor,
                    notBefore: DateTime.Now,
                    claims: claims,
                    expires: fechaExpiracion);

                var token = new JwtSecurityToken(header,payload);
                response.Token = new JwtSecurityTokenHandler().WriteToken(token);
                response.GivenName = identtiy.GivenName;
                response.IsSucess(success: response.Success = true,
                    GivenName:response.GivenName,
                    Toeken:response.Token);

            }
            catch (Exception ex)
            {

                throw;
            }
            return response;
        }

        public async Task<BaseResponse> RegisterAsync(RegisterUserDto request)
        {
            var response = new BaseResponse();
            try
            {
                var user = new ConsultorioUser()
                {
                    UserName = request.Usuario,
                    GivenName = request.GivenName,
                    FamilyName = request.FamilyName,
                    Email = request.Email,
                    EmailConfirmed = true,
                    PhoneNumber = request.PhoneNumber,
                };

                var result = await _userManager.CreateAsync(user, request.Password);
                if (result.Succeeded)
                {
                    // todo por implementar  Roles


                    //Todo envio de email ejemplo
                    //await _emailServices.SendEmailAsync(request.Email, "Imss - System", $"<strong><p>Felicidades!,{request.GivenName} {request.FamilyName}</p></strong>br />" +
                    //    $"<p>Su cuenta se ha dado de alta en Imss system exitosamente</p>");


                }
                else
                {
                    var sb = new StringBuilder();
                    foreach (var identityError in result.Errors)
                    {
                        sb.AppendFormat("{0}", identityError.Description);
                    }
                    //sb.Clear();
                    return response.Failure(errorMessage: Error.NotFound(code: "AnErrorOcurred", description: sb.ToString()));
                }
                response.IsSuccess(succes: response.Success = result.Succeeded);
            }
            catch (Exception ex)
            {

                string ErrorMessage = "An error ocurred while trying to regist the user";
                _logger.LogCritical(ex, "{ErroMessage}{Message}", ErrorMessage, ex.Message);
            }
            return response;
        }

        public async Task<BaseResponse> ResetPasswordAsync(ResetPasswordDtoRequest request)
        {
            var response = new BaseResponse();
            try
            {
                var user = await _userManager.FindByEmailAsync(request.Email);
                if(user is null)
                {
                    return response.Failure(errorMessage: UserErrors.NotFound(userResource: request.Email));
                }


                //NOTA: el token se prove por el email y el confirm password se valida en el frontend;
                var result = await _userManager.ResetPasswordAsync(user, request.Token, request.ResetNewPassword);
                // se deben hacer todas la validaciones igual que cuando se creo el usuario
                if(!result.Succeeded)
                {
                    var sb = new StringBuilder();
                    foreach (var identityError in result.Errors)
                    {
                        sb.AppendFormat("{0}", identityError.Description);
                    }
                    //sb.Clear();
                    return response.Failure(errorMessage: Error.NotFound(code: "AnErrorOcurred", description: sb.ToString()));
                }
                else
                {
                    //TODO se envia un email con la confiramcion de que se cambio el password exitosamente"
                    await _emailServices.SendEmailAsync(request.Email, "Imss - Cambio de password succeeded", "Your passwor was changed succeeded");
                }
                response.IsSuccess(succes: response.Success = result.Succeeded);
            }
            catch (Exception ex)
            {

                string ErrorMessage = "An error ocurred while tryingg to reset the user password";
                _logger.LogCritical(ex, "{ErrorMessage}{Message}", ErrorMessage, ex.Message);
            }
            return response;
        }

        public async Task<BaseResponse> SendTokenToResetPasswordAsync(GenerateTokenToResetPassword request
            )
        {
            var resposne = new BaseResponse();
            try
            {
                var user = await _userManager.FindByNameAsync(request.Usuario);
                if (user is null)
                {
                    return resposne.Failure(UserErrors.NotFound(userResource: request.Usuario));
                }


                var email = await _userManager.FindByEmailAsync(request.Email);
                if(email is null)
                {
                    return resposne.Failure(UserErrors.NotFound(userResource: request.Email));
                }

                var token = await _userManager.GeneratePasswordResetTokenAsync(user);

                // TODO: generar el link de resete de password 
                var host = $"https://localhost:7098/rest-password?email={request.Email}&{token}";

                await _emailServices.SendEmailAsync(request.Email, "Imss - Solicitud de reseteo de passwor",$"to recover your password, enter in the next link {host}");

                resposne.IsSuccess(succes: resposne.Success = true);

            }
            catch (Exception ex)
            {

                string ErrorMessage = "An erro ocurred while tryingg to reset the user password";
                _logger.LogCritical(ex, "{ErrorMessage}{Message}", ErrorMessage, ex.Message);
            }
            return resposne;
        }
    }
}
