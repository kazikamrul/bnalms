using MediatR;

namespace SchoolManagement.Application.Features.MemberInfos.Requests.Commands
{
    public class InActiveMemberInfoCommand : IRequest 
    {
        public int MemberInfoId { get; set; } 
    }
}
