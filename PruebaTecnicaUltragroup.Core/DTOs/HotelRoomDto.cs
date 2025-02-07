namespace PruebaTecnicaUltragroup.Core.DTOs
{
    public class HotelRoomDto
    {
        public int Id { get; set; }

        public int IdHotel { get; set; }

        public string Type { get; set; }

        public decimal BaseCost { get; set; }

        public decimal Tax { get; set; }

        public string Location { get; set; }

        public int Capacity { get; set; }
    }
}
