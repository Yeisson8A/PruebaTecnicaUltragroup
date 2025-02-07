using PruebaTecnicaUltragroup.Core.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PruebaTecnicaUltragroup.Core.Interfaces
{
    public interface IReservationRepository
    {
        Task<List<Reservation>> GetReservations();

        Task<Reservation> GetReservation(int id);

        Task InsertReservation(Reservation reservation);

        IEnumerable<Reservation> GetReservationsByRoomAndDateRange(int roomId, DateTime checkIn, DateTime checkOut);
    }
}
