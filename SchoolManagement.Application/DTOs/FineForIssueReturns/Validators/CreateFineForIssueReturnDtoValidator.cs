using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.FineForIssueReturns.Validators
{
    public class CreateFineForIssueReturnDtoValidator : AbstractValidator<CreateFineForIssueReturnDto>
    {
        public CreateFineForIssueReturnDtoValidator()  
        {
            Include(new IFineForIssueReturnDtoValidator()); 
        }
    }
}
