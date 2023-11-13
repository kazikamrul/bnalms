using MediatR;

namespace SchoolManagement.Application.Features.BookIssueAndSubmissions.Requests.Queries
{
    public class GetBookIssueListBySpRequest : IRequest<object>
    {
        public int BaseSchoolNameId { get; set; }
        public string SearchText { get; set; }
    }
} 
  