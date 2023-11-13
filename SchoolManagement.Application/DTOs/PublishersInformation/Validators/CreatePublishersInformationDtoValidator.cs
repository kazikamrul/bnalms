using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.PublishersInformation.Validators
{
    public class CreatePublishersInformationDtoValidator : AbstractValidator<CreatePublishersInformationDto>
    {
        public CreatePublishersInformationDtoValidator()  
        {
            Include(new IPublishersInformationDtoValidator()); 
        }
    }
}
