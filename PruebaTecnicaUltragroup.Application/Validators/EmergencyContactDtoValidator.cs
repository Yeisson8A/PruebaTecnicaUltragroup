using FluentValidation;
using PruebaTecnicaUltragroup.Core.DTOs;

namespace PruebaTecnicaUltragroup.Application.Validators
{
    public class EmergencyContactDtoValidator : AbstractValidator<EmergencyContactDto>
    {
        public EmergencyContactDtoValidator()
        {
            RuleFor(contact => contact.FullName).NotNull().WithMessage("The full name of the emergency contact is required")
                                                .Length(1, 200).WithMessage("The full name of the emergency contact must have a maximum length of 200 characters");
            RuleFor(contact => contact.ContactPhone).NotNull().WithMessage("The contact phone of the emergency contact is required")
                                                .Length(1, 50).WithMessage("The contact phone of the emergency contact must have a maximum length of 50 characters");
        }
    }
}
