using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.Base.Validators
{
    public class CreateBaseDtoValidator : AbstractValidator<CreateBasemDto>
    {
        public CreateBaseDtoValidator()  
        {
            Include(new IBaseDtoValidator()); 
        }
    }
}
