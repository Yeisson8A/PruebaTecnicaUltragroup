using System;

namespace PruebaTecnicaUltragroup.Core.DTOs
{
    public class ReservationDetailDto
    {
        public int Id { get; set; }

        public int IdReservation { get; set; }

        public string FullName { get; set; }

        public DateOnly BirthDate { get; set; }

        public string Gender { get; set; }

        public string DocumentType { get; set; }

        public string DocumentNumber { get; set; }

        public string Email { get; set; }

        public string ContactPhone { get; set; }
    }
}
