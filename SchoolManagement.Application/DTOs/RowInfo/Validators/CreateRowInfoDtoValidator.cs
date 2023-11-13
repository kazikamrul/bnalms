using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.RowInfo.Validators
{
    public class CreateRowInfoDtoValidator : AbstractValidator<CreateRowInfoDto>
    {
        public CreateRowInfoDtoValidator()  
        {
            Include(new IRowInfoDtoValidator()); 
        }
    }
}
