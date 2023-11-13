using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
 
namespace SchoolManagement.Application.DTOs.Language.Validators
{
    public class UpdateLanguageDtoValidator : AbstractValidator<LanguageDto>
    {
        public UpdateLanguageDtoValidator()
        {
            Include(new ILanguageDtoValidator());

            RuleFor(b => b.LanguageId).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}

