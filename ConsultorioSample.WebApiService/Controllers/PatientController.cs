using Consultorio.Models.Request;
using Consultorio.Models.Responses;
using Consultorio.Services.Interfaces;
using ConsultorioSample.WebApiService.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace ConsultorioSample.WebApiService.Controllers
{
    [ApiController]
    [Route("api/patient")]
    public class PatientController : ControllerBase
    {
        private readonly IPatientServices _services;

        public PatientController(IPatientServices services)
        {
            _services = services;
        }


        [HttpPost]
        public async Task<IActionResult> AddPetient(PatientDtoRequest patientRequest)
        {
            var resposne = await _services.AddAsync(patientRequest);

            return resposne.Success ? Ok(resposne) : resposne.ToProblemDetails();

        }

        [HttpGet("{id:Guid}")]
        public async Task<IActionResult> FindPetientById(Guid id)
        {
            var response = await _services.FindByIdAsync(id);

            return response.Success ? Ok(response): response.ToProblemDetails();

        }

        [HttpGet("GetPatientList")]
        public async Task<IActionResult> GetPatientsList()
        {
            var resposne = await _services.GetListAsync();

            return Ok(resposne);

        }
        [HttpPut("update/{id:Guid}")]
        public async Task<IActionResult> UpdatePatient(Guid id,PatientDtoRequest patientResources)
        {
            var response = await _services.UpdateAsync(id, patientResources);


            return response.Success ? Ok(response) : response.ToProblemDetails();

        }
        [HttpPut("Reactive/{id:Guid}")]
        public async Task<IActionResult> ReactivePatient(Guid id)
        {
            var response = await _services.ReactiveAsync(id);
            return response.Success ? Ok(response) : response.ToProblemDetails();
        }

        [HttpDelete("LogicDelete/{id:Guid}")]
        public async Task<IActionResult> LogicDeletePatient(Guid id)
        {
            var response = await _services.LogicDeleteAsync(id);
            return response.Success ? Ok(response) : response.ToProblemDetails();
        }

        [HttpDelete("Delete/{id:Guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var response = await _services.DeleteAsync(id);
            return response.Success ? Ok(response) : response.ToProblemDetails(); 
        }

    }
}
