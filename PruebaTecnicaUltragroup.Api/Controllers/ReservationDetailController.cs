using Microsoft.AspNetCore.Mvc;
using PruebaTecnicaUltragroup.Core.DTOs;
using PruebaTecnicaUltragroup.Application.Interfaces;

namespace PruebaTecnicaUltragroup.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationDetailController : ControllerBase
    {
        private readonly IReservationDetailApplication _reservationDetailApplication;

        public ReservationDetailController(IReservationDetailApplication reservationDetailApplication)
        {
            _reservationDetailApplication = reservationDetailApplication;
        }

        [HttpPost]
        public async Task<IActionResult> InsertReservationDetail(ReservationDetailDto reservationDetailDto)
        {
            if (reservationDetailDto == null)
            {
                return BadRequest();
            }

            var response = await _reservationDetailApplication.InsertReservationDetail(reservationDetailDto);

            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response.Message);
        }

        [HttpGet("{idReserva}")]
        public async Task<IActionResult> GetReservationDetails(int idReserva)
        {
            var response = await _reservationDetailApplication.GetReservationDetails(idReserva);

            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response.Message);
        }
    }
}
