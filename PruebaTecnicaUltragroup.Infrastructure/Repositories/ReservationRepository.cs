using Microsoft.EntityFrameworkCore;
using PruebaTecnicaUltragroup.Core.Entities;
using PruebaTecnicaUltragroup.Core.Interfaces;
using PruebaTecnicaUltragroup.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaTecnicaUltragroup.Infrastructure.Repositories
{
    public class ReservationRepository : IReservationRepository
    {
        private readonly DbpruebaUltragroupContext _context;

        public ReservationRepository(DbpruebaUltragroupContext context)
        {
            _context = context;
        }

        public async Task<Reservation> GetReservation(int id)
        {
            var reservation = await _context.Reservations.FindAsync(id);
            return reservation;
        }

        public async Task<List<Reservation>> GetReservations()
        {
            var reservations = await _context.Reservations.ToListAsync();
            return reservations;
        }

        public IEnumerable<Reservation> GetReservationsByRoomAndDateRange(int roomId, DateTime checkIn, DateTime checkOut)
        {
            return _context.Reservations.Where(r => r.IdRoom == roomId &&
                    (
                        (r.CheckInDate >= checkIn && r.CheckInDate <= checkOut) ||
                        (r.CheckOutDate >= checkIn && r.CheckOutDate <= checkOut) ||
                        (r.CheckInDate <= checkIn && r.CheckOutDate >= checkOut)
                    )).ToList();
        }

        public async Task InsertReservation(Reservation reservation)
        {
            await _context.Reservations.AddAsync(reservation);
        }
    }
}
