using MediatR;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.DTOs.NoticeType;
using SchoolManagement.Application.Models;

namespace SchoolManagement.Application.Features.NoticeTypes.Requests.Queries
{
    public class GetNoticeTypeListRequest : IRequest<PagedResult<NoticeTypeDto>>
    {
        public QueryParams QueryParams { get; set; }
    }
}
