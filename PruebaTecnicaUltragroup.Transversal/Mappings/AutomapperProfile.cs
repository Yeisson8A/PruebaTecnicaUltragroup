using AutoMapper;
using PruebaTecnicaUltragroup.Core.DTOs;
using PruebaTecnicaUltragroup.Core.Entities;

namespace PruebaTecnicaPCA.Transversal.Mappings
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<Hotel, HotelDto>().ReverseMap();
            CreateMap<HotelRoom, HotelRoomDto>().ReverseMap();
            CreateMap<Reservation, ReservationDto>().ReverseMap();
            CreateMap<ReservationDetail, ReservationDetailDto>().ReverseMap();
            CreateMap<EmergencyContact, EmergencyContactDto>().ReverseMap();
        }
    }
}
