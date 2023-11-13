using MediatR;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.MemberInfos.Requests.Queries
{
    public class GetMemberListForUserCreateRequest : IRequest<object>
    {
        public string Pno { get; set; }
    }
}   
   