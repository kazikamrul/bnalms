using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
 
namespace SchoolManagement.Application.DTOs.DamageInformationByLibrary.Validators
{
    public class UpdateDamageInformationByLibraryDtoValidator : AbstractValidator<DamageInformationByLibraryDto>
    {
        public UpdateDamageInformationByLibraryDtoValidator()
        {
            Include(new IDamageInformationByLibraryDtoValidator());

            RuleFor(b => b.DamageInformationByLibraryId).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}

