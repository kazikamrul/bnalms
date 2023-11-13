using MediatR;
using SchoolManagement.Application.DTOs.SecurityQuestion;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.SecurityQuestions.Requests.Commands
{
    public class UpdateSecurityQuestionCommand : IRequest<Unit>
    {
        public SecurityQuestionDto SecurityQuestionDto { get; set; }
    }
}
