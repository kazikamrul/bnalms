using MediatR;

namespace SchoolManagement.Application.Features.BookInformations.Requests.Queries
{
    public class GetBookIssueInfoByUserSpRequest : IRequest<object>
    {
        public int BookInformationId { get; set; }
    } 
} 
 