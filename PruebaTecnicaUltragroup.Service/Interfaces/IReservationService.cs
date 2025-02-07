using PruebaTecnicaUltragroup.Core.Entities;

namespace PruebaTecnicaUltragroup.Service.Interfaces
{
    public interface IReservationService
    {
        Task<List<Reservation>> GetReservations();

        Task<Reservation> GetReservation(int id);

        Task<bool> InsertReservation(Reservation reservation);
    }
}
