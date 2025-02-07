using FluentValidation;
using PruebaTecnicaUltragroup.Core.DTOs;

namespace PruebaTecnicaUltragroup.Application.Validators
{
    public class ReservationDtoValidator : AbstractValidator<ReservationDto>
    {
        public ReservationDtoValidator() {
            RuleFor(reservation => reservation.CheckInDate.Date).NotNull().WithMessage("The reservation check in date is required")
                                                .GreaterThanOrEqualTo(DateTime.Now.Date).WithMessage("The reservation check in date must be equal to or later than the current date");
            RuleFor(reservation => reservation.CheckOutDate.Date).NotNull().WithMessage("The reservation check out date is required")
                                                .GreaterThanOrEqualTo(DateTime.Now.Date).WithMessage("The reservation check out date must be equal to or later than the current date");
            RuleFor(reservation => reservation.IdRoom).NotNull().WithMessage("The room for reservation is required");
            RuleFor(reservation => reservation.IdEmergencyContact).NotNull().WithMessage("The emergency contact for reservation is required");
        }
    }
}
