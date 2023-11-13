using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
 
namespace SchoolManagement.Application.DTOs.BookInformation.Validators
{
    public class UpdateBookInformationDtoValidator : AbstractValidator<BookInformationDto>
    {
        public UpdateBookInformationDtoValidator()
        {
            Include(new IBookInformationDtoValidator());

            RuleFor(b => b.BookInformationId).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}

