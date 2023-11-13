using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.Area.Validators
{
    public class CreateAreaDtoValidator : AbstractValidator<CreateAreaDto>
    {
        public CreateAreaDtoValidator()  
        {
            Include(new IAreaDtoValidator()); 
        }
    }
}
