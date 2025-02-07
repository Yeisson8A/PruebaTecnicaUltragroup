using PruebaTecnicaUltragroup.Core.DTOs;
using PruebaTecnicaUltragroup.Application.Responses;

namespace PruebaTecnicaUltragroup.Application.Interfaces
{
    public interface IHotelApplication
    {
        Task<Response<List<HotelDto>>> GetHotels();

        Task<Response<HotelDto>> GetHotel(int id);

        Task<Response<bool>> InsertHotel(HotelDto hotelDto);

        Task<Response<bool>> UpdateHotel(HotelDto hotelDto);

        Task<Response<bool>> ChangeStateHotel(int id);

        Task<Response<List<HotelSearchDto>>> SearchHotels(DateTime checkIn, DateTime checkOut, int guests, string city);
    }
}
