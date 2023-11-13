using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.SourceInformation.Validators
{
    public class CreateSourceInformationDtoValidator : AbstractValidator<CreateSourceInformationDto>
    {
        public CreateSourceInformationDtoValidator()  
        {
            Include(new ISourceInformationDtoValidator()); 
        }
    }
}
