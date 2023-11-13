using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
 
namespace SchoolManagement.Application.DTOs.BookTitleInfo.Validators
{
    public class UpdateBookTitleInfoDtoValidator : AbstractValidator<BookTitleInfoDto>
    {
        public UpdateBookTitleInfoDtoValidator()
        {
            Include(new IBookTitleInfoDtoValidator());

            RuleFor(b => b.BookTitleInfoId).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}

