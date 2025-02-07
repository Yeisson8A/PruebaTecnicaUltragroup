using PruebaTecnicaUltragroup.Core.DTOs;
using PruebaTecnicaUltragroup.Core.Entities;

namespace PruebaTecnicaUltragroup.Service.Interfaces
{
    public interface IHotelService
    {
        Task<List<Hotel>> GetHotels();

        Task<Hotel> GetHotel(int id);
        
        Task<bool> InsertHotel(Hotel hotel);
        
        Task<bool> UpdateHotel(Hotel hotel);
        
        Task<bool> ChangeStateHotel(int id);

        Task<List<HotelSearchDto>> SearchHotels(DateTime checkIn, DateTime checkOut, int guests, string city);
    }
}
