using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.OnlineBookRequest.Validators
{
    public class CreateOnlineBookRequestDtoValidator : AbstractValidator<CreateOnlineBookRequestDto>
    {
        public CreateOnlineBookRequestDtoValidator()  
        {
            Include(new IOnlineBookRequestDtoValidator()); 
        }
    }
}
