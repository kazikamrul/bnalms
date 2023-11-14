using MediatR;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.DTOs.BookIssueAndSubmission;
using SchoolManagement.Application.Models;

namespace SchoolManagement.Application.Features.BookIssueAndSubmissions.Requests.Queries
{
    public class GetBookIssueAndSubmissionListRequest : IRequest<PagedResult<BookIssueAndSubmissionDto>>
    {
        public QueryParams QueryParams { get; set; }
        public int BaseSchoolNameId { get; set; }
    }
}
 