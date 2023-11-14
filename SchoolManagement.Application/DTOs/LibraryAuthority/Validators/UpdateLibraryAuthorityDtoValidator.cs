using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
 
namespace SchoolManagement.Application.DTOs.LibraryAuthority.Validators
{
    public class UpdateLibraryAuthorityDtoValidator : AbstractValidator<LibraryAuthorityDto>
    {
        public UpdateLibraryAuthorityDtoValidator()
        {
            Include(new ILibraryAuthorityDtoValidator());

            RuleFor(b => b.LibraryAuthorityId).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}

