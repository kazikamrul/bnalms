using MediatR;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.DTOs.SecurityQuestion;
using SchoolManagement.Application.Models;

namespace SchoolManagement.Application.Features.SecurityQuestions.Requests.Queries
{
    public class GetSecurityQuestionListRequest : IRequest<PagedResult<SecurityQuestionDto>>
    {
        public QueryParams QueryParams { get; set; }
    }
}
