using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.MainClass.Validators
{
    public class CreateMainClassDtoValidator : AbstractValidator<CreateMainClassDto>
    {
        public CreateMainClassDtoValidator()  
        {
            Include(new IMainClassDtoValidator()); 
        }
    }
}
