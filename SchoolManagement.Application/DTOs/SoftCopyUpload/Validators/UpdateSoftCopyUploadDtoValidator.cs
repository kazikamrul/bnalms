using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
 
namespace SchoolManagement.Application.DTOs.SoftCopyUpload.Validators
{
    public class UpdateSoftCopyUploadDtoValidator : AbstractValidator<CreateSoftCopyUploadDto>
    {
        public UpdateSoftCopyUploadDtoValidator()
        {
            Include(new ISoftCopyUploadDtoValidator());

            RuleFor(b => b.SoftCopyUploadId).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}

