using System;

namespace PruebaTecnicaUltragroup.Core.Entities;

public class ReservationDetail : BaseEntity
{
    public int IdReservation { get; set; }

    public string FullName { get; set; } = null!;

    public DateOnly BirthDate { get; set; }

    public string Gender { get; set; } = null!;

    public string DocumentType { get; set; } = null!;

    public string DocumentNumber { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string ContactPhone { get; set; } = null!;

    public virtual Reservation IdReservationNavigation { get; set; } = null!;
}
