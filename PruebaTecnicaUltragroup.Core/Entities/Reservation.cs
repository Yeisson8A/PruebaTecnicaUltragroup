using System;
using System.Collections.Generic;

namespace PruebaTecnicaUltragroup.Core.Entities;

public class Reservation : BaseEntity
{
    public DateTime CheckInDate { get; set; }

    public DateTime CheckOutDate { get; set; }

    public int IdRoom { get; set; }

    public int IdEmergencyContact { get; set; }

    public virtual EmergencyContact IdEmergencyContactNavigation { get; set; } = null!;

    public virtual HotelRoom IdRoomNavigation { get; set; } = null!;

    public virtual ICollection<ReservationDetail> ReservationDetails { get; set; } = new List<ReservationDetail>();
}
