using Microsoft.AspNetCore.Mvc;
using PruebaTecnicaUltragroup.Core.DTOs;
using PruebaTecnicaUltragroup.Application.Interfaces;

namespace PruebaTecnicaUltragroup.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelRoomController : ControllerBase
    {
        private readonly IHotelRoomApplication _hotelRoomApplication;

        public HotelRoomController(IHotelRoomApplication hotelRoomApplication)
        {
            _hotelRoomApplication = hotelRoomApplication;
        }

        [HttpPost]
        public async Task<IActionResult> InsertHotelRoom(HotelRoomDto hotelRoomDto)
        {
            if (hotelRoomDto == null)
            {
                return BadRequest();
            }

            var response = await _hotelRoomApplication.InsertHotelRoom(hotelRoomDto);

            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response.Message);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateHotel(int id, HotelRoomDto hotelRoomDto)
        {
            if (hotelRoomDto == null)
            {
                return BadRequest();
            }

            hotelRoomDto.Id = id;
            var response = await _hotelRoomApplication.UpdateHotelRoom(hotelRoomDto);

            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response.Message);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> ChangeStateHotelRoom(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            var response = await _hotelRoomApplication.ChangeStateHotelRoom(id);

            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response.Message);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetHotelRoom(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            var response = await _hotelRoomApplication.GetHotelRoom(id);

            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response.Message);
        }

        [HttpGet("Hotel/{idHotel}")]
        public async Task<IActionResult> GetHotelRooms(int idHotel)
        {
            var response = await _hotelRoomApplication.GetHotelRooms(idHotel);

            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response.Message);
        }
    }
}
