using PruebaTecnicaUltragroup.Core.DTOs;
using PruebaTecnicaUltragroup.Core.Entities;
using PruebaTecnicaUltragroup.Core.Interfaces;
using PruebaTecnicaUltragroup.Service.Interfaces;

namespace PruebaTecnicaUltragroup.Service.Services
{
    public class HotelService : IHotelService
    {
        private readonly IUnitOfWork _unitOfWork;

        public HotelService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> ChangeStateHotel(int id)
        {
            await _unitOfWork.HotelRepository.ChangeStateHotel(id);
            var rows = await _unitOfWork.SaveChangesAsync();
            return rows > 0;
        }

        public async Task<Hotel> GetHotel(int id)
        {
            return await _unitOfWork.HotelRepository.GetHotel(id);
        }

        public async Task<List<Hotel>> GetHotels()
        {
            return await _unitOfWork.HotelRepository.GetHotels();
        }

        public async Task<bool> InsertHotel(Hotel hotel)
        {
            await _unitOfWork.HotelRepository.InsertHotel(hotel);
            var rows = await _unitOfWork.SaveChangesAsync();
            return rows > 0;
        }

        public async Task<bool> UpdateHotel(Hotel hotel)
        {
            await _unitOfWork.HotelRepository.UpdateHotel(hotel);
            var rows = await _unitOfWork.SaveChangesAsync();
            return rows > 0;
        }

        private bool IsRoomAvailable(int roomId, DateTime checkIn, DateTime checkOut)
        {
            var reservations = _unitOfWork.ReservationRepository.GetReservationsByRoomAndDateRange(roomId, checkIn, checkOut);
            return !reservations.Any();
        }

        private IEnumerable<string> GetAvailableDates(int roomId, DateTime checkIn, DateTime checkOut)
        {
            return Enumerable.Range(0, (checkOut - checkIn).Days + 1)
                             .Select(offset => checkIn.AddDays(offset).ToString("yyyy-MM-dd"));
        }

        public async Task<List<HotelSearchDto>> SearchHotels(DateTime checkIn, DateTime checkOut, int guests, string city)
        {
            var hotels = await _unitOfWork.HotelRepository.GetHotelsByCity(city);

            var availableHotels = hotels
                .Select(hotel => new HotelSearchDto
                {
                    HotelId = hotel.Id,
                    HotelName = hotel.Name,
                    City = hotel.City,
                    AvailableRooms = hotel.HotelRooms
                        .Where(room => room.IsEnabled &&
                                       room.Capacity >= guests &&
                                       IsRoomAvailable(room.Id, checkIn, checkOut))
                        .Select(room => new HotelRoomSearchDto
                        {
                            RoomId = room.Id,
                            RoomType = room.Type,
                            PricePerNight = room.BaseCost + room.Tax,
                            AvailableDates = GetAvailableDates(room.Id, checkIn, checkOut)
                        }).ToList()
                }).ToList();

            return availableHotels;
        }
    }
}
