using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.OnlineChat.Validators
{
    public class CreateOnlineChatDtoValidator : AbstractValidator<CreateOnlineChatDto>
    {
        public CreateOnlineChatDtoValidator()
        {
            Include(new IOnlineChatDtoValidator());
        }
    }
}
