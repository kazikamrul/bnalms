using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.DemandBook.Validators
{
    public class CreateDemandBookDtoValidator : AbstractValidator<CreateDemandBookDto>
    {
        public CreateDemandBookDtoValidator()  
        {
            Include(new IDemandBookDtoValidator()); 
        }
    }
}
