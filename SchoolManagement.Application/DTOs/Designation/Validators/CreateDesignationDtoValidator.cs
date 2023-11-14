using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.Designation.Validators
{
    public class CreateDesignationDtoValidator : AbstractValidator<CreateDesignationDto>
    {
        public CreateDesignationDtoValidator()  
        {
            Include(new IDesignationDtoValidator()); 
        }
    }
}
