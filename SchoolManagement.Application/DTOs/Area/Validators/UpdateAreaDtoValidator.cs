using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
 
namespace SchoolManagement.Application.DTOs.Area.Validators
{
    public class UpdateAreaDtoValidator : AbstractValidator<AreaDto>
    {
        public UpdateAreaDtoValidator()
        {
            Include(new IAreaDtoValidator());

            RuleFor(b => b.AreaId).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}

