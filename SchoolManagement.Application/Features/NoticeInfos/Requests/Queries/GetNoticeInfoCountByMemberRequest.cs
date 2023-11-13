using MediatR;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.DTOs.NoticeInfo;
using SchoolManagement.Application.Models;

namespace SchoolManagement.Application.Features.NoticeInfos.Requests.Queries
{
    public class GetNoticeInfoCountByMemberRequest : IRequest<List<NoticeInfoDto>>
    {
        public int MemberInfoId { get; set; }
    }
}
