using AutoMapper;
using PruebaTecnicaUltragroup.Core.DTOs;
using PruebaTecnicaUltragroup.Application.Interfaces;
using PruebaTecnicaUltragroup.Application.Responses;
using PruebaTecnicaUltragroup.Application.Validators;
using PruebaTecnicaUltragroup.Core.Entities;
using PruebaTecnicaUltragroup.Service.Interfaces;

namespace PruebaTecnicaUltragroup.Application.Main
{
    public class HotelRoomApplication : IHotelRoomApplication
    {
        private readonly IHotelRoomService _hotelRoomService;
        private readonly IMapper _mapper;
        private readonly HotelRoomDtoValidator _hotelRoomDtoValidator;

        public HotelRoomApplication(IHotelRoomService hotelRoomService, IMapper mapper, HotelRoomDtoValidator hotelRoomDtoValidator)
        {
            _hotelRoomService = hotelRoomService;
            _mapper = mapper;
            _hotelRoomDtoValidator = hotelRoomDtoValidator;
        }

        public async Task<Response<bool>> ChangeStateHotelRoom(int id)
        {
            var response = new Response<bool>();

            try
            {
                response.Data = await _hotelRoomService.ChangeStateHotelRoom(id);

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

        public async Task<Response<HotelRoomDto>> GetHotelRoom(int id)
        {
            var response = new Response<HotelRoomDto>();

            try
            {
                var hotelRoom = await _hotelRoomService.GetHotelRoom(id);
                response.Data = _mapper.Map<HotelRoomDto>(hotelRoom);
                response.IsSuccess = true;
            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }
            return response;
        }

        public async Task<Response<List<HotelRoomDto>>> GetHotelRooms(int idHotel)
        {
            var response = new Response<List<HotelRoomDto>>();

            try
            {
                var hotelRooms = await _hotelRoomService.GetHotelRooms(idHotel);
                response.Data = _mapper.Map<List<HotelRoomDto>>(hotelRooms);
                response.IsSuccess = true;
            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }
            return response;
        }

        public async Task<Response<bool>> InsertHotelRoom(HotelRoomDto hotelRoomDto)
        {
            var response = new Response<bool>();
            var validation = _hotelRoomDtoValidator.Validate(hotelRoomDto);

            if (!validation.IsValid)
            {
                response.Message = "Validation Errors";
                response.Errors = validation.Errors;
                return response;
            }

            try
            {
                var hotelRoom = _mapper.Map<HotelRoom>(hotelRoomDto);
                response.Data = await _hotelRoomService.InsertHotelRoom(hotelRoom);

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

        public async Task<Response<bool>> UpdateHotelRoom(HotelRoomDto hotelRoomDto)
        {
            var response = new Response<bool>();
            var validation = _hotelRoomDtoValidator.Validate(hotelRoomDto);

            if (!validation.IsValid)
            {
                response.Message = "Validation Errors";
                response.Errors = validation.Errors;
                return response;
            }

            try
            {
                var hotelRoom = _mapper.Map<HotelRoom>(hotelRoomDto);
                response.Data = await _hotelRoomService.UpdateHotelRoom(hotelRoom);

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
