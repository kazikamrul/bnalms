using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
 
namespace SchoolManagement.Application.DTOs.ShelfInfo.Validators
{
    public class UpdateShelfInfoDtoValidator : AbstractValidator<ShelfInfoDto>
    {
        public UpdateShelfInfoDtoValidator()
        {
            Include(new IShelfInfoDtoValidator());

            RuleFor(b => b.ShelfInfoId).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}

