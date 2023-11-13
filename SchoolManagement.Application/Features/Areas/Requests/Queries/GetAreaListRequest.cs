using MediatR;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.DTOs.Area;
using SchoolManagement.Application.Models;

namespace SchoolManagement.Application.Features.Areas.Requests.Queries
{
    public class GetAreaListRequest : IRequest<PagedResult<AreaDto>>
    {
        public QueryParams QueryParams { get; set; }
    }
}
