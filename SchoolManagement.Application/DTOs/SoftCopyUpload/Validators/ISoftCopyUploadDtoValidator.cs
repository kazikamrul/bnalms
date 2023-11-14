using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
 
namespace SchoolManagement.Application.DTOs.SoftCopyUpload.Validators
{
    public class ISoftCopyUploadDtoValidator : AbstractValidator<ISoftCopyUploadDto>
    {
        public ISoftCopyUploadDtoValidator() 
        {
            RuleFor(b => b.TitleName)
                .NotEmpty().WithMessage("{PropertyName} is required.").MaximumLength(150).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters.");
        }
    }
}
