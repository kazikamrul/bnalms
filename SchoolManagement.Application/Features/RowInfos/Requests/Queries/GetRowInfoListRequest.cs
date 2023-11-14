using MediatR;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.DTOs.RowInfo;
using SchoolManagement.Application.Models;

namespace SchoolManagement.Application.Features.RowInfos.Requests.Queries
{
    public class GetRowInfoListRequest : IRequest<PagedResult<RowInfoDto>>
    {
        public QueryParams QueryParams { get; set; }
    }
}
