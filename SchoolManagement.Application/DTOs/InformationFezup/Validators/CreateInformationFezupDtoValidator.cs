using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.InformationFezup.Validators
{
    public class CreateInformationFezupDtoValidator : AbstractValidator<CreateInformationFezupDto>
    {
        public CreateInformationFezupDtoValidator()  
        {
            Include(new IInformationFezupDtoValidator()); 
        }
    }
}
