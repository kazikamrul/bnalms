using MediatR;

namespace SchoolManagement.Application.Features.OnlineChats.Requests.Commands
{
    public class ChangeSeenStatusCommand : IRequest
    {
        public int OnlineChatId { get; set; }
        public int Status { get; set; }
    }
}
