using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
 
namespace SchoolManagement.Application.DTOs.BookIssueAndSubmission.Validators
{
    public class UpdateBookIssueAndSubmissionDtoValidator : AbstractValidator<BookIssueAndSubmissionDto>
    {
        //public UpdateBookIssueAndSubmissionDtoValidator()
        //{
        //    Include(new IBookIssueAndSubmissionDtoValidator());

        //    RuleFor(b => b.BookIssueAndSubmissionId).NotNull().WithMessage("{PropertyName} must be present");
        //}
    }
}

