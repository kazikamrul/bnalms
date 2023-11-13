using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.HelpLine.Validators
{
    public class CreateHelpLineDtoValidator : AbstractValidator<CreateHelpLineDto>
    {
        public CreateHelpLineDtoValidator()  
        {
            Include(new IHelpLineDtoValidator()); 
        }
    }
}
