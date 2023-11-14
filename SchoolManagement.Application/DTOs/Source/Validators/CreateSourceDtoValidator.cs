using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.Source.Validators
{
    public class CreateSourceDtoValidator : AbstractValidator<CreateSourceDto>
    {
        public CreateSourceDtoValidator()  
        {
            Include(new ISourceDtoValidator()); 
        }
    }
}
