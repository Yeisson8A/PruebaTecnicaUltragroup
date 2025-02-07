using PruebaTecnicaUltragroup.Core.Entities;
using PruebaTecnicaUltragroup.Core.Interfaces;
using PruebaTecnicaUltragroup.Service.Interfaces;

namespace PruebaTecnicaUltragroup.Service.Services
{
    public class ReservationDetailService : IReservationDetailService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ReservationDetailService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<ReservationDetail>> GetReservationDetails(int idReservation)
        {
            return await _unitOfWork.ReservationDetailRepository.GetReservationDetails(idReservation);
        }

        public async Task<bool> InsertReservationDetail(ReservationDetail reservationDetail)
        {
            await _unitOfWork.ReservationDetailRepository.InsertReservationDetail(reservationDetail);
            var rows = await _unitOfWork.SaveChangesAsync();
            return rows > 0;
        }
    }
}
