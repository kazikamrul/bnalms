using MediatR;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.DTOs.EventInfo;
using SchoolManagement.Application.Models;

namespace SchoolManagement.Application.Features.EventInfos.Requests.Queries
{
    public class GetEventInfoListRequest : IRequest<PagedResult<EventInfoDto>>
    {
        public QueryParams QueryParams { get; set; }
    }
}
