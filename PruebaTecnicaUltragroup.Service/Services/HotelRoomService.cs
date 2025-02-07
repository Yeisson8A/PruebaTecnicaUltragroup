using PruebaTecnicaUltragroup.Core.Entities;
using PruebaTecnicaUltragroup.Core.Interfaces;
using PruebaTecnicaUltragroup.Service.Interfaces;

namespace PruebaTecnicaUltragroup.Service.Services
{
    public class HotelRoomService : IHotelRoomService
    {
        private readonly IUnitOfWork _unitOfWork;

        public HotelRoomService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> ChangeStateHotelRoom(int id)
        {
            await _unitOfWork.HotelRoomRepository.ChangeStateHotelRoom(id);
            var rows = await _unitOfWork.SaveChangesAsync();
            return rows > 0;
        }

        public async Task<HotelRoom> GetHotelRoom(int id)
        {
            return await _unitOfWork.HotelRoomRepository.GetHotelRoom(id);
        }

        public async Task<List<HotelRoom>> GetHotelRooms(int idHotel)
        {
            return await _unitOfWork.HotelRoomRepository.GetHotelRooms(idHotel);
        }

        public async Task<bool> InsertHotelRoom(HotelRoom hotelRoom)
        {
            await _unitOfWork.HotelRoomRepository.InsertHotelRoom(hotelRoom);
            var rows = await _unitOfWork.SaveChangesAsync();
            return rows > 0;
        }

        public async Task<bool> UpdateHotelRoom(HotelRoom hotelRoom)
        {
            await _unitOfWork.HotelRoomRepository.UpdateHotelRoom(hotelRoom);
            var rows = await _unitOfWork.SaveChangesAsync();
            return rows > 0;
        }
    }
}
