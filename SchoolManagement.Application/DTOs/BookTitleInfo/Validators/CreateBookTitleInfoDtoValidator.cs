using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.BookTitleInfo.Validators
{
    public class CreateBookTitleInfoDtoValidator : AbstractValidator<CreateBookTitleInfoDto>
    {
        public CreateBookTitleInfoDtoValidator()  
        {
            Include(new IBookTitleInfoDtoValidator()); 
        }
    }
}
