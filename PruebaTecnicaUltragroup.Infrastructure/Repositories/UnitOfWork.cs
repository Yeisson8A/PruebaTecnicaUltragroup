using PruebaTecnicaUltragroup.Core.Interfaces;
using PruebaTecnicaUltragroup.Infrastructure.Data;
using System.Threading.Tasks;

namespace PruebaTecnicaUltragroup.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbpruebaUltragroupContext _context;
        private readonly IHotelRepository _hotelRepository;
        private readonly IHotelRoomRepository _hotelRoomRepository;
        private readonly IReservationRepository _reservationRepository;
        private readonly IReservationDetailRepository _reservationDetailRepository;
        private readonly IEmergencyContactRepository _emergencyContactRepository;

        public UnitOfWork(DbpruebaUltragroupContext context)
        {
            _context = context;
        }

        public IHotelRepository HotelRepository => _hotelRepository ?? new HotelRepository(_context);

        public IHotelRoomRepository HotelRoomRepository => _hotelRoomRepository ?? new HotelRoomRepository(_context);

        public IReservationRepository ReservationRepository => _reservationRepository ?? new ReservationRepository(_context);

        public IReservationDetailRepository ReservationDetailRepository => _reservationDetailRepository ?? new ReservationDetailRepository(_context);

        public IEmergencyContactRepository EmergencyContactRepository => _emergencyContactRepository ?? new EmergencyContactRepository(_context);

        public void Dispose()
        {
            if (_context != null)
            {
                _context.Dispose();
            }
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
