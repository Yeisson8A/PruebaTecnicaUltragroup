using FluentValidation;
using PruebaTecnicaUltragroup.Core.DTOs;

namespace PruebaTecnicaUltragroup.Application.Validators
{
    public class HotelDtoValidator : AbstractValidator<HotelDto>
    {
        public HotelDtoValidator() {
            RuleFor(hotel => hotel.Name).NotNull().WithMessage("The hotel's name is required")
                                        .Length(1, 100).WithMessage("The hotel name must have a maximum length of 100 characters");
        }
    }
}
