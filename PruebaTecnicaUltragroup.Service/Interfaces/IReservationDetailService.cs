using PruebaTecnicaUltragroup.Core.Entities;

namespace PruebaTecnicaUltragroup.Service.Interfaces
{
    public interface IReservationDetailService
    {
        Task<List<ReservationDetail>> GetReservationDetails(int idReservation);

        Task<bool> InsertReservationDetail(ReservationDetail reservationDetail);
    }
}
