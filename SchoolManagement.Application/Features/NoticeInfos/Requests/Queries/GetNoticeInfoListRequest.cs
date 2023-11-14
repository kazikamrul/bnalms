using MediatR;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.DTOs.NoticeInfo;
using SchoolManagement.Application.Models;

namespace SchoolManagement.Application.Features.NoticeInfos.Requests.Queries
{
    public class GetNoticeInfoListRequest : IRequest<PagedResult<NoticeInfoDto>>
    {
        public QueryParams QueryParams { get; set; }
        public int NoticeTypeId { get; set; } 
    }
}
