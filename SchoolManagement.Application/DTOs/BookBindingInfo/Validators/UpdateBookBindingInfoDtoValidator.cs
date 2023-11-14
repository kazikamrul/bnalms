using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
 
namespace SchoolManagement.Application.DTOs.BookBindingInfo.Validators
{
    public class UpdateBookBindingInfoDtoValidator : AbstractValidator<BookBindingInfoDto>
    {
        public UpdateBookBindingInfoDtoValidator()
        {
            Include(new IBookBindingInfoDtoValidator());

            RuleFor(b => b.BookBindingInfoId).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}

