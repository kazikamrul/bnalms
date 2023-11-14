using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.BookBindingInfo.Validators
{
    public class CreateBookBindingInfoDtoValidator : AbstractValidator<CreateBookBindingInfoDto>
    {
        public CreateBookBindingInfoDtoValidator()  
        {
            Include(new IBookBindingInfoDtoValidator()); 
        }
    }
}
