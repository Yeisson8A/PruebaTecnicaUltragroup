using System.Collections.Generic;

namespace PruebaTecnicaUltragroup.Core.DTOs
{
    public class HotelRoomSearchDto
    {
        public long RoomId { get; set; }

        public string RoomType { get; set; }

        public decimal PricePerNight { get; set; }

        public IEnumerable<string> AvailableDates { get; set; }
    }
}
