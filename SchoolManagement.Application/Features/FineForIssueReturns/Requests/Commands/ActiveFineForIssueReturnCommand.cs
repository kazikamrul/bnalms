using MediatR;

namespace SchoolManagement.Application.Features.FineForIssueReturns.Requests.Commands
{
    public class ActiveFineForIssueReturnCommand : IRequest 
    {
        public int FineForIssueReturnId { get; set; } 
    }
}
