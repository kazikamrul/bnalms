using MediatR;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.DTOs.NoticeInfo;
using SchoolManagement.Application.Models;

namespace SchoolManagement.Application.Features.NoticeInfos.Requests.Queries
{
    public class GetNoticeInfoListByMemberRequest : IRequest<PagedResult<NoticeInfoDto>>
    {
        public int MemberInfoId { get; set; }
        public QueryParams QueryParams { get; set; }
    }
}
