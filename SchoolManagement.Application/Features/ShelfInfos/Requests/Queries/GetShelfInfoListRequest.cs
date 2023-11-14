using MediatR;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.DTOs.ShelfInfo;
using SchoolManagement.Application.Models;

namespace SchoolManagement.Application.Features.ShelfInfos.Requests.Queries
{
    public class GetShelfInfoListRequest : IRequest<PagedResult<ShelfInfoDto>>
    {
        public QueryParams QueryParams { get; set; }
    }
}
