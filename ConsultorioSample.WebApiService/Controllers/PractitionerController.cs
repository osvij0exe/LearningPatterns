using Consultorio.Models.Request;
using Consultorio.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ConsultorioSample.WebApiService.Controllers
{
    [ApiController]
    [Route("api/Practitioner")]
    public class PractitionerController : ControllerBase
    {
        private readonly IPractitionerServices _practitionerServices;

        public PractitionerController(IPractitionerServices practitionerServices)
        {
            _practitionerServices = practitionerServices;
        }

        [HttpPost]
        public async Task<IActionResult> AddPractitioner(PractitionerDtoRequest practitionerDtoRequest)
        {
            var response = await _practitionerServices.AddAsync(practitionerDtoRequest);

            return response.Success ? Ok(response) : BadRequest(response);


        }

        [HttpGet("{id:Guid}")]
        public async Task<IActionResult> FindPractitionerById(Guid id)
        {
            var response = await _practitionerServices.FindByIdAsync(id);

            return response.Success ? Ok(response) : NotFound(response);


        }
        [HttpGet("PractitionerList")]
        public async Task<IActionResult> PractitionerList()
        {
            var resposne = await _practitionerServices.ListAsync();

            return Ok(resposne);
        }

        [HttpDelete("DeletePractitioner/{id:Guid}")]
        public async Task<IActionResult> DeletePractitioner(Guid id)
        {
            var response = await _practitionerServices.DeleteAsync(id);

            return response.Success ? Ok(response) : NotFound(response);
        }

        [HttpDelete("LogicDeletePractitioner/{id:Guid}")]
        public async Task<IActionResult> LogicDeletePractitioner(Guid id)
        {
            var response = await _practitionerServices.LogicDeleteAsync(id);

            return response.Success ? Ok(response) : NotFound(response);
        }

        [HttpPut("UpdatePractitioner/{id:Guid}")]
        public async Task<IActionResult> UpdatePractitioner(Guid id, PractitionerDtoRequest practitionerResources)
        {
            var response = await _practitionerServices.UpdateAsync(id, practitionerResources);

            return response.Success ? Ok(response) : NotFound(response);

        }

        [HttpPut("ReacvtivePractitioner/{id:Guid}")]
        public async Task<IActionResult> ReactivePractitioner(Guid id)
        {
            var response = await _practitionerServices.ReactiveAsync(id);
            return response.Success ? Ok(response) : NotFound(response);
        }

    }
}
