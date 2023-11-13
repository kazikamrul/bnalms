using MediatR;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.MemberInfos.Requests.Queries
{
    public class GetMemberNameByIdRequest : IRequest<List<SelectedModel>> 
    {
        public int MemberInfoId { get; set; }   
    }
}   
   