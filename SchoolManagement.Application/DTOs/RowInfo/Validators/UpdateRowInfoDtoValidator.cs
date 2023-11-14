using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
 
namespace SchoolManagement.Application.DTOs.RowInfo.Validators
{
    public class UpdateRowInfoDtoValidator : AbstractValidator<RowInfoDto>
    {
        public UpdateRowInfoDtoValidator()
        {
            Include(new IRowInfoDtoValidator());

            RuleFor(b => b.RowInfoId).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}

