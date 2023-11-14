using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.SecurityQuestions.Requests.Commands
{
    public class DeleteSecurityQuestionCommand : IRequest
    {
        public int SecurityQuestionId { get; set; }
    }
}
