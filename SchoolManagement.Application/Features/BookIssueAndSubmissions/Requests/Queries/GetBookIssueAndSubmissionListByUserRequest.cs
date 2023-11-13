using MediatR;
using SchoolManagement.Application.DTOs.BookIssueAndSubmission;

namespace SchoolManagement.Application.Features.BookIssueAndSubmissions.Requests.Queries
{
    public class GetBookIssueAndSubmissionListByUserRequest : IRequest<List<BookIssueAndSubmissionDto>>
    {
        public int MemberInfoId { get; set; }
    }
}

 