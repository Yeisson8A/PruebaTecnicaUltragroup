using System.Collections.Generic;

namespace PruebaTecnicaUltragroup.Core.Entities;

public class EmergencyContact : BaseEntity
{
    public string FullName { get; set; } = null!;

    public string ContactPhone { get; set; } = null!;

    public virtual ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
}
