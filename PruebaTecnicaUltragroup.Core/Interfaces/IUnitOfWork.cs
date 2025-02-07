using System;
using System.Threading.Tasks;

namespace PruebaTecnicaUltragroup.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IHotelRepository HotelRepository { get; }

        IHotelRoomRepository HotelRoomRepository { get; }

        IReservationRepository ReservationRepository { get; }

        IReservationDetailRepository ReservationDetailRepository { get; }

        IEmergencyContactRepository EmergencyContactRepository { get; }

        Task<int> SaveChangesAsync();
    }
}
