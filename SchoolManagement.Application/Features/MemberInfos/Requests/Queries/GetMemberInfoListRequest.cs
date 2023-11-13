using MediatR;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.DTOs.MemberInfo;
using SchoolManagement.Application.Models;

namespace SchoolManagement.Application.Features.MemberInfos.Requests.Queries
{
    public class GetMemberInfoListRequest : IRequest<PagedResult<MemberInfoDto>>
    {
        public QueryParams QueryParams { get; set; }
    }
}
