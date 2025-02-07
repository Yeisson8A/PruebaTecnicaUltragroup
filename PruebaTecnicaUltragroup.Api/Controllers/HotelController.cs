using Microsoft.AspNetCore.Mvc;
using PruebaTecnicaUltragroup.Core.DTOs;
using PruebaTecnicaUltragroup.Application.Interfaces;

namespace PruebaTecnicaPCA.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelController : ControllerBase
    {
        private readonly IHotelApplication _hotelApplication;

        public HotelController(IHotelApplication hotelApplication)
        {
            _hotelApplication = hotelApplication;
        }

        [HttpPost]
        public async Task<IActionResult> InsertHotel(HotelDto hotelDto)
        {
            if (hotelDto == null)
            {
                return BadRequest();
            }

            var response = await _hotelApplication.InsertHotel(hotelDto);

            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response.Message);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateHotel(int id, HotelDto hotelDto)
        {
            if (hotelDto == null)
            {
                return BadRequest();
            }

            hotelDto.Id = id;
            var response = await _hotelApplication.UpdateHotel(hotelDto);

            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response.Message);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> ChangeStateHotel(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            var response = await _hotelApplication.ChangeStateHotel(id);

            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response.Message);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetHotel(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            var response = await _hotelApplication.GetHotel(id);

            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response.Message);
        }

        [HttpGet]
        public async Task<IActionResult> GetHotels()
        {
            var response = await _hotelApplication.GetHotels();

            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response.Message);
        }

        [HttpGet("Search")]
        public async Task<IActionResult> SearchHotels([FromQuery] string checkIn, string checkOut, int guests, string city)
        {
            var response = await _hotelApplication.SearchHotels(DateTime.Parse(checkIn), DateTime.Parse(checkOut), guests, city);

            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response.Message);
        }
    }
}
