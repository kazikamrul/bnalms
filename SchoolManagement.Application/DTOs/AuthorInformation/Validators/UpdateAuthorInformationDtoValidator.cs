using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
 
namespace SchoolManagement.Application.DTOs.AuthorInformation.Validators
{
    public class UpdateAuthorInformationDtoValidator : AbstractValidator<AuthorInformationDto>
    {
        public UpdateAuthorInformationDtoValidator()
        {
            Include(new IAuthorInformationDtoValidator());

            RuleFor(b => b.AuthorInformationId).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}

