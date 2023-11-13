using MediatR;
using SchoolManagement.Application.DTOs.MemberInfo;

namespace SchoolManagement.Application.Features.MemberInfos.Requests.Queries
{
    public class GetMemberInformationListByDepartmentIdRequest : IRequest<List<MemberInfoDto>>
    {
        
        public int BaseSchoolNameId { get; set; }
    } 
}

