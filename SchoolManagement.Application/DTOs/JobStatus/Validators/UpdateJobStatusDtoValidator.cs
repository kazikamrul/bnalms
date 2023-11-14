using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
 
namespace SchoolManagement.Application.DTOs.JobStatus.Validators
{
    public class UpdateJobStatusDtoValidator : AbstractValidator<JobStatusDto>
    {
        public UpdateJobStatusDtoValidator()
        {
            Include(new IJobStatusDtoValidator());

            RuleFor(b => b.JobStatusId).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}

