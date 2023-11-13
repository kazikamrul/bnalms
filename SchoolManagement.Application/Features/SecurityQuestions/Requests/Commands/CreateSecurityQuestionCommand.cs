using MediatR;
using SchoolManagement.Application.DTOs.SecurityQuestion;
using SchoolManagement.Application.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.SecurityQuestions.Requests.Commands
{
    public class CreateSecurityQuestionCommand : IRequest<BaseCommandResponse>
    {
        public CreateSecurityQuestionDto SecurityQuestionDto { get; set; }
    }
}
