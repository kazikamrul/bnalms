using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.AuthorInformation.Validators
{
    public class CreateAuthorInformationDtoValidator : AbstractValidator<CreateAuthorInformationDto>
    {
        public CreateAuthorInformationDtoValidator()  
        {
            Include(new IAuthorInformationDtoValidator()); 
        }
    }
}
