using MediatR;

namespace SchoolManagement.Application.Features.MemberInfos.Requests.Commands
{
    public class ActiveMemberInfoCommand : IRequest 
    {
        public int MemberInfoId { get; set; } 
    }
}
