using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.EventInfo.Validators
{
    public class CreateEventInfoDtoValidator : AbstractValidator<CreateEventInfoDto>
    {
        public CreateEventInfoDtoValidator()  
        {
            Include(new IEventInfoDtoValidator()); 
        }
    }
}
