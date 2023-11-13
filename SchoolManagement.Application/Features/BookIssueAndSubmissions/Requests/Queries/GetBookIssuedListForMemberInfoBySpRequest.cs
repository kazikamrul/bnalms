using MediatR;

namespace SchoolManagement.Application.Features.BookIssueAndSubmissions.Requests.Queries
{
    public class GetBookIssuedListForMemberInfoBySpRequest : IRequest<object>
    {
        public int MemberInfoId { get; set; }
        public string SearchText { get; set; }
    }
} 
  