using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
 
namespace SchoolManagement.Application.DTOs.OnlineBookRequest.Validators
{
    public class UpdateOnlineBookRequestDtoValidator : AbstractValidator<OnlineBookRequestDto>
    {
        public UpdateOnlineBookRequestDtoValidator()
        {
            Include(new IOnlineBookRequestDtoValidator());

            RuleFor(b => b.OnlineBookRequestId).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}

