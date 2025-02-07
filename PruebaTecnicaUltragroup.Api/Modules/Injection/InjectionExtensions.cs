using PruebaTecnicaUltragroup.Application.Interfaces;
using PruebaTecnicaUltragroup.Application.Main;
using PruebaTecnicaUltragroup.Core.Interfaces;
using PruebaTecnicaUltragroup.Infrastructure.Repositories;
using PruebaTecnicaUltragroup.Service.Interfaces;
using PruebaTecnicaUltragroup.Service.Services;

namespace Ecommerce.Services.WebApi.Modules.Injection
{
    public static class InjectionExtensions
    {
        public static IServiceCollection AddInjection(this IServiceCollection services)
        {
            // Add repository dependencies
            services.AddScoped<IHotelRepository, HotelRepository>();
            services.AddScoped<IHotelRoomRepository, HotelRoomRepository>();
            services.AddScoped<IReservationRepository, ReservationRepository>();
            services.AddScoped<IReservationDetailRepository, ReservationDetailRepository>();
            services.AddScoped<IEmergencyContactRepository, EmergencyContactRepository>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            // Add service dependencies
            services.AddScoped<IHotelService, HotelService>();
            services.AddScoped<IHotelRoomService, HotelRoomService>();
            services.AddScoped<IReservationService, ReservationService>();
            services.AddScoped<IReservationDetailService, ReservationDetailService>();
            services.AddScoped<IEmergencyContactService, EmergencyContactService>();
            // Add application dependencies
            services.AddScoped<IHotelApplication, HotelApplication>();
            services.AddScoped<IHotelRoomApplication, HotelRoomApplication>();
            services.AddScoped<IReservationApplication, ReservationApplication>();
            services.AddScoped<IReservationDetailApplication, ReservationDetailApplication>();
            services.AddScoped<IEmergencyContactApplication, EmergencyContactApplication>();
            return services;
        }
    }
}
