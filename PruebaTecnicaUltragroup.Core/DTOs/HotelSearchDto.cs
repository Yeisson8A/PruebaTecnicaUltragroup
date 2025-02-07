using System.Collections.Generic;

namespace PruebaTecnicaUltragroup.Core.DTOs
{
    public class HotelSearchDto
    {
        public long HotelId { get; set; }

        public string HotelName { get; set; }

        public string City { get; set; }

        public List<HotelRoomSearchDto> AvailableRooms { get; set; }
    }
}
