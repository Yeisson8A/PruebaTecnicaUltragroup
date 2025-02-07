using PruebaTecnicaUltragroup.Core.Entities;

namespace PruebaTecnicaUltragroup.Service.Interfaces
{
    public interface IHotelRoomService
    {
        Task<List<HotelRoom>> GetHotelRooms(int idHotel);

        Task<HotelRoom> GetHotelRoom(int id);

        Task<bool> InsertHotelRoom(HotelRoom hotelRoom);

        Task<bool> UpdateHotelRoom(HotelRoom hotelRoom);

        Task<bool> ChangeStateHotelRoom(int id);
    }
}
