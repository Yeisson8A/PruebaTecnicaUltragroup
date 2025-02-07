using System.Collections.Generic;

namespace PruebaTecnicaUltragroup.Core.Entities;

public class Hotel : BaseHotelEntity
{
    public string Name { get; set; } = null!;

    public string City { get; set; } = null!;

    public virtual ICollection<HotelRoom> HotelRooms { get; set; } = new List<HotelRoom>();
}
