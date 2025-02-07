using PruebaTecnicaUltragroup.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PruebaTecnicaUltragroup.Core.Interfaces
{
    public interface IReservationDetailRepository
    {
        Task<List<ReservationDetail>> GetReservationDetails(int idReservation);

        Task InsertReservationDetail(ReservationDetail reservationDetail);
    }
}
