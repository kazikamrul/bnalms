using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.AuthorityCategory.Validators
{
    public class CreateAuthorityCategoryDtoValidator : AbstractValidator<CreateAuthorityCategoryDto>
    {
        public CreateAuthorityCategoryDtoValidator()  
        {
            Include(new IAuthorityCategoryDtoValidator()); 
        }
    }
}
