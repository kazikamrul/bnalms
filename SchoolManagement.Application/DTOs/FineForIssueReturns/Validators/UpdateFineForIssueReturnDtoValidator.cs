using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
 
namespace SchoolManagement.Application.DTOs.FineForIssueReturns.Validators
{
    public class UpdateFineForIssueReturnDtoValidator : AbstractValidator<FineForIssueReturnDto>
    {
        public UpdateFineForIssueReturnDtoValidator()
        {
            Include(new IFineForIssueReturnDtoValidator());

            RuleFor(b => b.FineForIssueReturnId).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}

