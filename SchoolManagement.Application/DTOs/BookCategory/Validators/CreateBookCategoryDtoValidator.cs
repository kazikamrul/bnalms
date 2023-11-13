using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.BookCategory.Validators
{
    public class CreateBookCategoryDtoValidator : AbstractValidator<CreateBookCategoryDto>
    {
        public CreateBookCategoryDtoValidator()  
        {
            Include(new IBookCategoryDtoValidator()); 
        }
    }
}
