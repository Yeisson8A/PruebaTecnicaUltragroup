using AutoMapper;
using PruebaTecnicaUltragroup.Application.Validators;
using PruebaTecnicaUltragroup.Core.DTOs;
using PruebaTecnicaUltragroup.Application.Interfaces;
using PruebaTecnicaUltragroup.Application.Responses;
using PruebaTecnicaUltragroup.Core.Entities;
using PruebaTecnicaUltragroup.Service.Interfaces;

namespace PruebaTecnicaUltragroup.Application.Main
{
    public class HotelApplication : IHotelApplication
    {
        private readonly IHotelService _hotelService;
        private readonly IMapper _mapper;
        private readonly HotelDtoValidator _hotelDtoValidator;

        public HotelApplication(IHotelService hotelService, IMapper mapper, HotelDtoValidator hotelDtoValidator)
        {
            _hotelService = hotelService;
            _mapper = mapper;
            _hotelDtoValidator = hotelDtoValidator;
        }

        public async Task<Response<bool>> ChangeStateHotel(int id)
        {
            var response = new Response<bool>();

            try
            {
                response.Data = await _hotelService.ChangeStateHotel(id);

                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Successfull";
                }
            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }
            return response;
        }

        public async Task<Response<HotelDto>> GetHotel(int id)
        {
            var response = new Response<HotelDto>();

            try
            {
                var hotel = await _hotelService.GetHotel(id);
                response.Data = _mapper.Map<HotelDto>(hotel);
                response.IsSuccess = true;
            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }
            return response;
        }

        public async Task<Response<List<HotelDto>>> GetHotels()
        {
            var response = new Response<List<HotelDto>>();

            try
            {
                var hotels = await _hotelService.GetHotels();
                response.Data = _mapper.Map<List<HotelDto>>(hotels);
                response.IsSuccess = true;
            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }
            return response;
        }

        public async Task<Response<bool>> InsertHotel(HotelDto hotelDto)
        {
            var response = new Response<bool>();
            var validation = _hotelDtoValidator.Validate(hotelDto);

            if (!validation.IsValid)
            {
                response.Message = "Validation Errors";
                response.Errors = validation.Errors;
                return response;
            }

            try
            {
                var hotel = _mapper.Map<Hotel>(hotelDto);
                response.Data = await _hotelService.InsertHotel(hotel);

                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Successfull";
                }
            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }
            return response;
        }

        public async Task<Response<List<HotelSearchDto>>> SearchHotels(DateTime checkIn, DateTime checkOut, int guests, string city)
        {
            var response = new Response<List<HotelSearchDto>>();

            try
            {
                var availableHotels = await _hotelService.SearchHotels(checkIn, checkOut, guests, city);
                response.Data = availableHotels;
                response.IsSuccess = true;
            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }
            return response;
        }

        public async Task<Response<bool>> UpdateHotel(HotelDto hotelDto)
        {
            var response = new Response<bool>();
            var validation = _hotelDtoValidator.Validate(hotelDto);

            if (!validation.IsValid)
            {
                response.Message = "Validation Errors";
                response.Errors = validation.Errors;
                return response;
            }

            try
            {
                var hotel = _mapper.Map<Hotel>(hotelDto);
                response.Data = await _hotelService.UpdateHotel(hotel);

                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Successfull";
                }
            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }
            return response;
        }
    }
}
