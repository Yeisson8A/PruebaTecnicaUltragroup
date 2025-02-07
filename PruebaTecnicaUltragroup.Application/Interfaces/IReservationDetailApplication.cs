using PruebaTecnicaUltragroup.Core.DTOs;
using PruebaTecnicaUltragroup.Application.Responses;

namespace PruebaTecnicaUltragroup.Application.Interfaces
{
    public interface IReservationDetailApplication
    {
        Task<Response<List<ReservationDetailDto>>> GetReservationDetails(int idReservation);

        Task<Response<bool>> InsertReservationDetail(ReservationDetailDto reservationDetailDto);
    }
}
