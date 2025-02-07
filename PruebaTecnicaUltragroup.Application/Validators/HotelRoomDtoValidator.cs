using FluentValidation;
using PruebaTecnicaUltragroup.Core.DTOs;

namespace PruebaTecnicaUltragroup.Application.Validators
{
    public class HotelRoomDtoValidator : AbstractValidator<HotelRoomDto>
    {
        public HotelRoomDtoValidator()
        {
            RuleFor(room => room.IdHotel).NotNull().WithMessage("The hotel room is required");
            RuleFor(room => room.Type).NotNull().WithMessage("The hotel room type is required")
                                        .Length(1, 100).WithMessage("The hotel room type must have a maximum length of 100 characters");
            RuleFor(room => room.BaseCost).NotNull().WithMessage("The hotel room base cost is required")
                                        .GreaterThan(0).WithMessage("The hotel room base cost must be greather tan 0");
            RuleFor(room => room.Tax).NotNull().WithMessage("The hotel room tax is required")
                                        .GreaterThan(0).WithMessage("The hotel room tax must be greather tan 0");
            RuleFor(room => room.Location).NotNull().WithMessage("The hotel room location is required")
                                        .Length(1, 100).WithMessage("The hotel room location must have a maximum length of 100 characters");
        }
    }
}
