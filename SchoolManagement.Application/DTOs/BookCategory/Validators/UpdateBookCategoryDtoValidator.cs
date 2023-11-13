using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
 
namespace SchoolManagement.Application.DTOs.BookCategory.Validators
{
    public class UpdateBookCategoryDtoValidator : AbstractValidator<BookCategoryDto>
    {
        public UpdateBookCategoryDtoValidator()
        {
            Include(new IBookCategoryDtoValidator());

            RuleFor(b => b.BookCategoryId).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}

