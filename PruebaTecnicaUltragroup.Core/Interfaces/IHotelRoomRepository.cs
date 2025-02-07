using PruebaTecnicaUltragroup.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PruebaTecnicaUltragroup.Core.Interfaces
{
    public interface IHotelRoomRepository
    {
        Task<List<HotelRoom>> GetHotelRooms(int idHotel);

        Task<HotelRoom> GetHotelRoom(int id);

        Task InsertHotelRoom(HotelRoom hotelRoom);

        Task UpdateHotelRoom(HotelRoom hotelRoom);

        Task ChangeStateHotelRoom(int id);
    }
}
