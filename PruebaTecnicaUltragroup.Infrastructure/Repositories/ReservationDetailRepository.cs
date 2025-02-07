using Microsoft.EntityFrameworkCore;
using PruebaTecnicaUltragroup.Core.Entities;
using PruebaTecnicaUltragroup.Core.Interfaces;
using PruebaTecnicaUltragroup.Infrastructure.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaTecnicaUltragroup.Infrastructure.Repositories
{
    public class ReservationDetailRepository : IReservationDetailRepository
    {
        private readonly DbpruebaUltragroupContext _context;

        public ReservationDetailRepository(DbpruebaUltragroupContext context)
        {
            _context = context;
        }

        public async Task<List<ReservationDetail>> GetReservationDetails(int idReservation)
        {
            var reservationDetails = await _context.ReservationDetails.Where(x => x.IdReservation == idReservation).ToListAsync();
            return reservationDetails;
        }

        public async Task InsertReservationDetail(ReservationDetail reservationDetail)
        {
            await _context.ReservationDetails.AddAsync(reservationDetail);
        }
    }
}
