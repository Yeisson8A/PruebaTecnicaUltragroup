using PruebaTecnicaUltragroup.Core.Entities;
using PruebaTecnicaUltragroup.Core.Interfaces;
using PruebaTecnicaUltragroup.Service.Interfaces;

namespace PruebaTecnicaUltragroup.Service.Services
{
    public class ReservationService : IReservationService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ReservationService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Reservation> GetReservation(int id)
        {
            return await _unitOfWork.ReservationRepository.GetReservation(id);
        }

        public async Task<List<Reservation>> GetReservations()
        {
            return await _unitOfWork.ReservationRepository.GetReservations();
        }

        public async Task<bool> InsertReservation(Reservation reservation)
        {
            await _unitOfWork.ReservationRepository.InsertReservation(reservation);
            var rows = await _unitOfWork.SaveChangesAsync();
            return rows > 0;
        }
    }
}
