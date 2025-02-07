using PruebaTecnicaUltragroup.Application.Validators;

namespace Ecommerce.Services.WebApi.Modules.Validator
{
    public static class ValidatorExtensions
    {
        public static IServiceCollection AddValidator(this IServiceCollection services)
        {
            services.AddTransient<HotelDtoValidator>();
            services.AddTransient<HotelRoomDtoValidator>();
            services.AddTransient<ReservationDtoValidator>();
            services.AddTransient<ReservationDetailDtoValidator>();
            services.AddTransient<EmergencyContactDtoValidator>();
            return services;
        }
    }
}
