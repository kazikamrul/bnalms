using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.Language.Validators
{
    public class CreateLanguageDtoValidator : AbstractValidator<CreateLanguageDto>
    {
        public CreateLanguageDtoValidator()  
        {
            Include(new ILanguageDtoValidator()); 
        }
    }
}
