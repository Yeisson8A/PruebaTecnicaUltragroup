using AutoMapper;
using PruebaTecnicaUltragroup.Core.DTOs;
using PruebaTecnicaUltragroup.Application.Interfaces;
using PruebaTecnicaUltragroup.Application.Responses;
using PruebaTecnicaUltragroup.Application.Validators;
using PruebaTecnicaUltragroup.Core.Entities;
using PruebaTecnicaUltragroup.Service.Interfaces;

namespace PruebaTecnicaUltragroup.Application.Main
{
    public class ReservationDetailApplication : IReservationDetailApplication
    {
        private readonly IReservationDetailService _reservationDetailService;
        private readonly IMapper _mapper;
        private readonly ReservationDetailDtoValidator _reservationDetailDtoValidator;

        public ReservationDetailApplication(IReservationDetailService reservationDetailService, IMapper mapper, ReservationDetailDtoValidator reservationDetailDtoValidator)
        {
            _reservationDetailService = reservationDetailService;
            _mapper = mapper;
            _reservationDetailDtoValidator = reservationDetailDtoValidator;
        }

        public async Task<Response<List<ReservationDetailDto>>> GetReservationDetails(int idReservation)
        {
            var response = new Response<List<ReservationDetailDto>>();

            try
            {
                var reservationDetails = await _reservationDetailService.GetReservationDetails(idReservation);
                response.Data = _mapper.Map<List<ReservationDetailDto>>(reservationDetails);
                response.IsSuccess = true;
            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }
            return response;
        }

        public async Task<Response<bool>> InsertReservationDetail(ReservationDetailDto reservationDetailDto)
        {
            var response = new Response<bool>();
            var validation = _reservationDetailDtoValidator.Validate(reservationDetailDto);

            if (!validation.IsValid)
            {
                response.Message = "Validation Errors";
                response.Errors = validation.Errors;
                return response;
            }

            try
            {
                var reservationDetail = _mapper.Map<ReservationDetail>(reservationDetailDto);
                response.Data = await _reservationDetailService.InsertReservationDetail(reservationDetail);

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
