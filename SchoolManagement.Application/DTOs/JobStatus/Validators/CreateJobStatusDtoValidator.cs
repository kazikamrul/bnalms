using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.JobStatus.Validators
{
    public class CreateJobStatusDtoValidator : AbstractValidator<CreateJobStatusDto>
    {
        public CreateJobStatusDtoValidator()  
        {
            Include(new IJobStatusDtoValidator()); 
        }
    }
}
