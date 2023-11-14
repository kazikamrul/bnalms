using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.ReaderInformation.Validators
{
    public class CreateReaderInformationDtoValidator : AbstractValidator<CreateReaderInformationDto>
    {
        public CreateReaderInformationDtoValidator()  
        {
            Include(new IReaderInformationDtoValidator()); 
        }
    }
}
