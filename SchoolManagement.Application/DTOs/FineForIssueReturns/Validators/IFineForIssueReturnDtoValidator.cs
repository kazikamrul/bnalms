using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
 
namespace SchoolManagement.Application.DTOs.FineForIssueReturns.Validators
{
    public class IFineForIssueReturnDtoValidator : AbstractValidator<IFineForIssueReturnDto>
    {
        //public IFineForIssueReturnDtoValidator() 
        //{
        //    RuleFor(b => b.FineForIssueReturnName)
        //        .NotEmpty().WithMessage("{PropertyName} is required.").MaximumLength(150).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters.");
        //}
    }
}
