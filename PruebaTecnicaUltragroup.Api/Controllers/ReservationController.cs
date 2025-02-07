using Microsoft.AspNetCore.Mvc;
using PruebaTecnicaUltragroup.Core.DTOs;
using PruebaTecnicaUltragroup.Application.Interfaces;

namespace PruebaTecnicaUltragroup.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        private readonly IReservationApplication _reservationApplication;

        public ReservationController(IReservationApplication reservationApplication)
        {
            _reservationApplication = reservationApplication;
        }

        [HttpPost]
        public async Task<IActionResult> InsertReservation(ReservationDto reservationDto)
        {
            if (reservationDto == null)
            {
                return BadRequest();
            }

            var response = await _reservationApplication.InsertReservation(reservationDto);

            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response.Message);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetReservation(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            var response = await _reservationApplication.GetReservation(id);

            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response.Message);
        }

        [HttpGet]
        public async Task<IActionResult> GetReservations()
        {
            var response = await _reservationApplication.GetReservations();

            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response.Message);
        }
    }
}
