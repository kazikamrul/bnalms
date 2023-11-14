using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.ShelfInfo.Validators
{
    public class CreateShelfInfoDtoValidator : AbstractValidator<CreateShelfInfoDto>
    {
        public CreateShelfInfoDtoValidator()  
        {
            Include(new IShelfInfoDtoValidator()); 
        }
    }
}
