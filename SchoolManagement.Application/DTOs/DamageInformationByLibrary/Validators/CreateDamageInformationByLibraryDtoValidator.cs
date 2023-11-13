using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.DamageInformationByLibrary.Validators
{
    public class CreateDamageInformationByLibraryDtoValidator : AbstractValidator<CreateDamageInformationByLibraryDto>
    {
        public CreateDamageInformationByLibraryDtoValidator()  
        {
            Include(new IDamageInformationByLibraryDtoValidator()); 
        }
    }
}
