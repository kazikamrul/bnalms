using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.FeeCategory.Validators
{
    public class CreateFeeCategoryDtoValidator : AbstractValidator<CreateFeeCategoryDto>
    {
        public CreateFeeCategoryDtoValidator()  
        {
            Include(new IFeeCategoryDtoValidator()); 
        }
    }
}
