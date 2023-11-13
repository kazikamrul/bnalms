using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.FeeInformation.Validators
{
    public class CreateFeeInformationDtoValidator : AbstractValidator<CreateFeeInformationDto>
    {
        public CreateFeeInformationDtoValidator()  
        {
            Include(new IFeeInformationDtoValidator()); 
        }
    }
}
