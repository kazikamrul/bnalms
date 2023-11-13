using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.BookInformation.Validators
{
    public class CreateBookInformationDtoValidator : AbstractValidator<CreateBookInformationDto>
    {
        public CreateBookInformationDtoValidator()  
        {
            Include(new IBookInformationDtoValidator()); 
        }
    }
}
