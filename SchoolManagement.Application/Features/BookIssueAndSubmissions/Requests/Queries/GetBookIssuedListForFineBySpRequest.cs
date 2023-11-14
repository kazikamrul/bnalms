using MediatR;

namespace SchoolManagement.Application.Features.BookIssueAndSubmissions.Requests.Queries
{
    public class GetBookIssuedListForFineBySpRequest : IRequest<object>
    {
        public int MemberInfoId { get; set; }
        public int BaseSchoolNameId { get; set; } 
        public string SearchText { get; set; }
    }
} 
   