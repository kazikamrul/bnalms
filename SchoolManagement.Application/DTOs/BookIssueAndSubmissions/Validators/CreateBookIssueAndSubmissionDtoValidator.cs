using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.BookIssueAndSubmission.Validators
{
    public class CreateBookIssueAndSubmissionDtoValidator : AbstractValidator<CreateBookIssueAndSubmissionDto>
    {
        public CreateBookIssueAndSubmissionDtoValidator()  
        {
            Include(new IBookIssueAndSubmissionDtoValidator()); 
        }
    }
}
