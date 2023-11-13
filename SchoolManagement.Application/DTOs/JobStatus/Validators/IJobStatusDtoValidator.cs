using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
 
namespace SchoolManagement.Application.DTOs.JobStatus.Validators
{
    public class IJobStatusDtoValidator : AbstractValidator<IJobStatusDto>
    {
        public IJobStatusDtoValidator() 
        {
            RuleFor(b => b.JobStatusName)
                .NotEmpty().WithMessage("{PropertyName} is required.").MaximumLength(150).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters.");
        }
    }
}
