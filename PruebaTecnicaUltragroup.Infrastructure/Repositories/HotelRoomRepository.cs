using Microsoft.EntityFrameworkCore;
using PruebaTecnicaUltragroup.Core.Entities;
using PruebaTecnicaUltragroup.Core.Interfaces;
using PruebaTecnicaUltragroup.Infrastructure.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaTecnicaUltragroup.Infrastructure.Repositories
{
    public class HotelRoomRepository : IHotelRoomRepository
    {
        private readonly DbpruebaUltragroupContext _context;

        public HotelRoomRepository(DbpruebaUltragroupContext context)
        {
            _context = context;
        }

        public async Task ChangeStateHotelRoom(int id)
        {
            var hotelRoomModified = await _context.HotelRooms.FindAsync(id);
            hotelRoomModified.IsEnabled = !hotelRoomModified.IsEnabled;
        }

        public async Task<HotelRoom> GetHotelRoom(int id)
        {
            var hotelRoom = await _context.HotelRooms.FindAsync(id);
            return hotelRoom;
        }

        public async Task<List<HotelRoom>> GetHotelRooms(int idHotel)
        {
            var hotelRooms = await _context.HotelRooms.Where(x => x.IdHotel == idHotel).ToListAsync();
            return hotelRooms;
        }

        public async Task InsertHotelRoom(HotelRoom hotelRoom)
        {
            await _context.HotelRooms.AddAsync(hotelRoom);
        }

        public async Task UpdateHotelRoom(HotelRoom hotelRoom)
        {
            var hotelRoomModified = await _context.HotelRooms.FindAsync(hotelRoom.Id);
            hotelRoomModified.Type = hotelRoom.Type;
            hotelRoomModified.BaseCost = hotelRoom.BaseCost;
            hotelRoomModified.Tax = hotelRoom.Tax;
            hotelRoomModified.Location = hotelRoom.Location;
            hotelRoomModified.Capacity = hotelRoom.Capacity;
        }
    }
}
