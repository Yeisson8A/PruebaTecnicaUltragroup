using PruebaTecnicaUltragroup.Core.DTOs;
using PruebaTecnicaUltragroup.Application.Responses;

namespace PruebaTecnicaUltragroup.Application.Interfaces
{
    public interface IReservationApplication
    {
        Task<Response<List<ReservationDto>>> GetReservations();

        Task<Response<ReservationDto>> GetReservation(int id);

        Task<Response<bool>> InsertReservation(ReservationDto reservationDto);
    }
}
