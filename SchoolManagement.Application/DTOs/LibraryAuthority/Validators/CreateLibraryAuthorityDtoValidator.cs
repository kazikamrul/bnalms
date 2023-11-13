using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.LibraryAuthority.Validators
{
    public class CreateLibraryAuthorityDtoValidator : AbstractValidator<CreateLibraryAuthorityDto>
    {
        public CreateLibraryAuthorityDtoValidator()  
        {
            Include(new ILibraryAuthorityDtoValidator()); 
        }
    }
}
