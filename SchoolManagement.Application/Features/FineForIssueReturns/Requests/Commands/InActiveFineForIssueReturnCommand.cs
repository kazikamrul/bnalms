using MediatR;

namespace SchoolManagement.Application.Features.FineForIssueReturns.Requests.Commands
{
    public class InActiveFineForIssueReturnCommand : IRequest 
    {
        public int FineForIssueReturnId { get; set; } 
    }
}
