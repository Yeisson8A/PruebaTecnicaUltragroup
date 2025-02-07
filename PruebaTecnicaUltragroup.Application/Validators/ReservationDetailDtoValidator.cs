using FluentValidation;
using PruebaTecnicaUltragroup.Core.DTOs;

namespace PruebaTecnicaUltragroup.Application.Validators
{
    public class ReservationDetailDtoValidator : AbstractValidator<ReservationDetailDto>
    {
        public ReservationDetailDtoValidator()
        {
            RuleFor(detail => detail.IdReservation).NotNull().WithMessage("The reservation's id is required");
            RuleFor(detail => detail.FullName).NotNull().WithMessage("The guest's full name is required")
                                                .Length(1, 200).WithMessage("The guest's full name must have a maximum length of 200 characters");
            RuleFor(detail => detail.BirthDate).NotNull().WithMessage("The guest's birth date is required")
                                                .LessThanOrEqualTo(DateOnly.FromDateTime(DateTime.Now)).WithMessage("The guest's birth date must be equal to or previous than the current date");
            RuleFor(detail => detail.Gender).NotNull().WithMessage("The guest's gender is required")
                                                .Length(1, 50).WithMessage("The guest's gender must have a maximum length of 50 characters");
            RuleFor(detail => detail.DocumentType).NotNull().WithMessage("The guest's document type is required")
                                                .Length(1, 50).WithMessage("The guest's document type must have a maximum length of 50 characters");
            RuleFor(detail => detail.DocumentNumber).NotNull().WithMessage("The guest's document number is required")
                                                .Length(1, 50).WithMessage("The guest's document number must have a maximum length of 50 characters");
            RuleFor(detail => detail.Email).NotNull().WithMessage("The guest's email is required")
                                                .Length(1, 50).WithMessage("The guest's email must have a maximum length of 100 characters")
                                                .EmailAddress().WithMessage("The guest's email is invalid");
            RuleFor(detail => detail.ContactPhone).NotNull().WithMessage("The guest's contact phone is required")
                                                .Length(1, 50).WithMessage("The guest's contact phone must have a maximum length of 50 characters");
        }
    }
}
