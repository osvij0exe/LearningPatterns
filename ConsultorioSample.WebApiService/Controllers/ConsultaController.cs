using Consultorio.Models.Request;
using Consultorio.Models.Responses;
using Consultorio.Services.Interfaces;
using ConsultorioSample.WebApiService.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace ConsultorioSample.WebApiService.Controllers
{
    [ApiController]
    [Route("api/consulta")]
    public class ConsultaController : ControllerBase
    {
        private readonly IConsultaServices _consultaServices;

        public ConsultaController(IConsultaServices consultaServices)
        {
            _consultaServices = consultaServices;
        }

        [HttpPost]
        public async Task<IActionResult> AddConsulta(ConsultaDtoRequest consultaDtoRequest)
        {
            var response = await _consultaServices.AddConsultaAsync(consultaDtoRequest);

            return response.Success ? Ok(response) : response.ToProblemDetails() ;
        }
        [HttpGet("patientApoinments")]
        public async Task<IActionResult> GetPateintApoinments(Guid patientId)
        {
            var resposne = await _consultaServices.GetPatientAppoinmetsAsync(patientId);
            return resposne.Success ? Ok(resposne) : resposne.ToProblemDetails();
        }
        [HttpGet("practitionerApoinments")]
        public async Task<IActionResult> GetPractitionerApoinments(Guid practitionerId)
        {
            var resposne = await _consultaServices.GetPractitonerAppoinmetsAsync(practitionerId);
            return resposne.Success ? Ok(resposne) : resposne.ToProblemDetails();
        }

        [HttpGet("consultorioApoinments")]
        public async Task<IActionResult> GetConsultorioApoinments(Guid consultorioId)
        {
            var resposne = await _consultaServices.GetConsultorioAppoinmetsAsync(consultorioId);
            return resposne.Success ? Ok(resposne) : resposne.ToProblemDetails();
        }
        [HttpGet("Apoinments")]
        public async Task<IActionResult> GetApoinments()
        {
            var resposne = await _consultaServices.GetConsultaListAsync();
            return resposne.Success ? Ok(resposne) : resposne.ToProblemDetails();
        }
        [HttpGet("Apoinments/{id:Guid}")]
        public async Task<IActionResult> GetApoinmentById(Guid id)
        {
            var resposne = await _consultaServices.FindConsultaByIdAsync(id);
            return resposne.Success ? Ok(resposne) : resposne.ToProblemDetails();
        }
        [HttpPut("Apoinments/{id:Guid}")]
        public async Task<IActionResult> GetApoinmentById(Guid id,ConsultaDtoRequest consultaRsources)
        {
            var resposne = await _consultaServices.UpdateConsultaAsync(id, consultaRsources);
            return resposne.Success ? Ok(resposne) : resposne.ToProblemDetails();
        }

        [HttpDelete("Apoinments/{id:Guid}")]
        public async Task<IActionResult> DeleteApoinmentById(Guid id)
        {
            var resposne = await _consultaServices.DeleteCosnultaAsync(id);
            return resposne.Success ? Ok(resposne) : resposne.ToProblemDetails();
        }


    }
}
