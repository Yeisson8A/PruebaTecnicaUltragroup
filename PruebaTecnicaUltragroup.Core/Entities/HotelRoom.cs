using System.Collections.Generic;

namespace PruebaTecnicaUltragroup.Core.Entities;

public class HotelRoom : BaseHotelEntity
{
    public int IdHotel { get; set; }

    public string Type { get; set; } = null!;

    public decimal BaseCost { get; set; }

    public decimal Tax { get; set; }

    public string Location { get; set; } = null!;

    public int Capacity { get; set; }

    public virtual Hotel IdHotelNavigation { get; set; } = null!;

    public virtual ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
}
