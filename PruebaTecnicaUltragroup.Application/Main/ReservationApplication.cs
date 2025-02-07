using AutoMapper;
using PruebaTecnicaUltragroup.Core.DTOs;
using PruebaTecnicaUltragroup.Application.Interfaces;
using PruebaTecnicaUltragroup.Application.Responses;
using PruebaTecnicaUltragroup.Application.Validators;
using PruebaTecnicaUltragroup.Core.Entities;
using PruebaTecnicaUltragroup.Service.Interfaces;

namespace PruebaTecnicaUltragroup.Application.Main
{
    public class ReservationApplication : IReservationApplication
    {
        private readonly IReservationService _reservationService;
        private readonly IMapper _mapper;
        private readonly ReservationDtoValidator _reservationDtoValidator;

        public ReservationApplication(IReservationService reservationService, IMapper mapper, ReservationDtoValidator reservationDtoValidator)
        {
            _reservationService = reservationService;
            _mapper = mapper;
            _reservationDtoValidator = reservationDtoValidator;
        }

        public async Task<Response<ReservationDto>> GetReservation(int id)
        {
            var response = new Response<ReservationDto>();

            try
            {
                var reservation = await _reservationService.GetReservation(id);
                response.Data = _mapper.Map<ReservationDto>(reservation);
                response.IsSuccess = true;
            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }
            return response;
        }

        public async Task<Response<List<ReservationDto>>> GetReservations()
        {
            var response = new Response<List<ReservationDto>>();

            try
            {
                var reservations = await _reservationService.GetReservations();
                response.Data = _mapper.Map<List<ReservationDto>>(reservations);
                response.IsSuccess = true;
            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }
            return response;
        }

        public async Task<Response<bool>> InsertReservation(ReservationDto reservationDto)
        {
            var response = new Response<bool>();
            var validation = _reservationDtoValidator.Validate(reservationDto);

            if (!validation.IsValid)
            {
                response.Message = "Validation Errors";
                response.Errors = validation.Errors;
                return response;
            }

            try
            {
                var reservation = _mapper.Map<Reservation>(reservationDto);
                response.Data = await _reservationService.InsertReservation(reservation);

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
