using System;

namespace PruebaTecnicaUltragroup.Core.DTOs
{
    public class ReservationDto
    {
        public int Id { get; set; }

        public DateTime CheckInDate { get; set; }

        public DateTime CheckOutDate { get; set; }

        public int IdRoom { get; set; }

        public int IdEmergencyContact { get; set; }
    }
}
