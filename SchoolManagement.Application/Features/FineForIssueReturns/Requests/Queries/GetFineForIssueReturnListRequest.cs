using MediatR;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.DTOs.FineForIssueReturns;
using SchoolManagement.Application.Models;

namespace SchoolManagement.Application.Features.FineForIssueReturns.Requests.Queries
{
    public class GetFineForIssueReturnListRequest : IRequest<PagedResult<FineForIssueReturnDto>>
    {
        public QueryParams QueryParams { get; set; }
        public int BaseSchoolNameId { get; set; }
    }
}
