using MediatR;

namespace SchoolManagement.Application.Features.BookIssueAndSubmissions.Requests.Queries
{
    public class GetBookIssueAndSubmissionListByBaseSchoolNameIdSpRequest : IRequest<object>
    {
        public int BaseSchoolNameId { get; set; }
        public string SearchText { get; set; }
    }
} 
    