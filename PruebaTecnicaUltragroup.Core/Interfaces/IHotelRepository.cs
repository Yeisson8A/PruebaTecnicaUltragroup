using PruebaTecnicaUltragroup.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PruebaTecnicaUltragroup.Core.Interfaces
{
    public interface IHotelRepository
    {
        Task<List<Hotel>> GetHotels();

        Task<Hotel> GetHotel(int id);
        
        Task InsertHotel(Hotel hotel);
        
        Task UpdateHotel(Hotel hotel);
        
        Task ChangeStateHotel(int id);

        Task<List<Hotel>> GetHotelsByCity(string city);
    }
}
