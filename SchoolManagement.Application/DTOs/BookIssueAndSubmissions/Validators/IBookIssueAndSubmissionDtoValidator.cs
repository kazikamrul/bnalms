using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
 
namespace SchoolManagement.Application.DTOs.BookIssueAndSubmission.Validators
{
    public class IBookIssueAndSubmissionDtoValidator : AbstractValidator<IBookIssueAndSubmissionDto>
    {
        //public IBookIssueAndSubmissionDtoValidator() 
        //{
        //    RuleFor(b => b.BookIssueAndSubmissionName)
        //        .NotEmpty().WithMessage("{PropertyName} is required.").MaximumLength(150).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters.");
        //}
    }
}
