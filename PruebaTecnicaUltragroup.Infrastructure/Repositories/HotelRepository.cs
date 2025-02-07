using Microsoft.EntityFrameworkCore;
using PruebaTecnicaUltragroup.Core.Entities;
using PruebaTecnicaUltragroup.Core.Interfaces;
using PruebaTecnicaUltragroup.Infrastructure.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaTecnicaUltragroup.Infrastructure.Repositories
{
    public class HotelRepository : IHotelRepository
    {
        private readonly DbpruebaUltragroupContext _context;

        public HotelRepository(DbpruebaUltragroupContext context)
        {
            _context = context;
        }

        public async Task ChangeStateHotel(int id)
        {
            var hotelModified = await _context.Hotels.FindAsync(id);
            hotelModified.IsEnabled = !hotelModified.IsEnabled;
        }

        public async Task<Hotel> GetHotel(int id)
        {
            var hotel = await _context.Hotels.FindAsync(id);
            return hotel;
        }

        public async Task<List<Hotel>> GetHotels()
        {
            var hotels = await _context.Hotels.ToListAsync();
            return hotels;
        }

        public async Task<List<Hotel>> GetHotelsByCity(string city)
        {
            var hotels = await _context.Hotels.Where(x => x.City == city).ToListAsync();
            return hotels;
        }

        public async Task InsertHotel(Hotel hotel)
        {
            await _context.Hotels.AddAsync(hotel);
        }

        public async Task UpdateHotel(Hotel hotel)
        {
            var hotelModified = await _context.Hotels.FindAsync(hotel.Id);
            hotelModified.Name = hotel.Name;
            hotelModified.City = hotel.City;
        }
    }
}
