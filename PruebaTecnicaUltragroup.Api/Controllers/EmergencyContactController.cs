using Microsoft.AspNetCore.Mvc;
using PruebaTecnicaUltragroup.Core.DTOs;
using PruebaTecnicaUltragroup.Application.Interfaces;

namespace PruebaTecnicaUltragroup.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmergencyContactController : ControllerBase
    {
        private readonly IEmergencyContactApplication _emergencyContactApplication;

        public EmergencyContactController(IEmergencyContactApplication emergencyContactApplication)
        {
            _emergencyContactApplication = emergencyContactApplication;
        }

        [HttpPost]
        public async Task<IActionResult> InsertEmergencyContact(EmergencyContactDto emergencyContactDto)
        {
            if (emergencyContactDto == null)
            {
                return BadRequest();
            }

            var response = await _emergencyContactApplication.InsertEmergencyContact(emergencyContactDto);

            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response.Message);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmergencyContact(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            var response = await _emergencyContactApplication.GetEmergencyContact(id);

            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response.Message);
        }

        [HttpGet]
        public async Task<IActionResult> GetEmergencyContacts()
        {
            var response = await _emergencyContactApplication.GetEmergencyContacts();

            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response.Message);
        }
    }
}
