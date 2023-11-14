using MediatR;
using SchoolManagement.Application.DTOs.SecurityQuestion;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.SecurityQuestions.Requests.Queries
{
    public class GetSecurityQuestionDetailRequest : IRequest<SecurityQuestionDto>
    {
        public int SecurityQuestionId { get; set; }
    }
}
