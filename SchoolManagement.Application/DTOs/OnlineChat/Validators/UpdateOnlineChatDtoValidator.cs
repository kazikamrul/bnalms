using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.OnlineChat.Validators
{
    public class UpdateOnlineChatDtoValidator : AbstractValidator<OnlineChatDto>
    {
        public UpdateOnlineChatDtoValidator()
        {
            Include(new IOnlineChatDtoValidator());

            //RuleFor(p => p.OnlineChatId).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}
