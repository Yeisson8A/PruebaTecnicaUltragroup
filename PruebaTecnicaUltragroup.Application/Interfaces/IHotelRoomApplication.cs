using PruebaTecnicaUltragroup.Core.DTOs;
using PruebaTecnicaUltragroup.Application.Responses;

namespace PruebaTecnicaUltragroup.Application.Interfaces
{
    public interface IHotelRoomApplication
    {
        Task<Response<List<HotelRoomDto>>> GetHotelRooms(int idHotel);

        Task<Response<HotelRoomDto>> GetHotelRoom(int id);

        Task<Response<bool>> InsertHotelRoom(HotelRoomDto hotelRoomDto);

        Task<Response<bool>> UpdateHotelRoom(HotelRoomDto hotelRoomDto);

        Task<Response<bool>> ChangeStateHotelRoom(int id);
    }
}
