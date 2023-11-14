using MediatR;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.DTOs.Base;
using SchoolManagement.Application.Models;

namespace SchoolManagement.Application.Features.Bases.Requests.Queries
{
    public class GetBaseListRequest : IRequest<PagedResult<BasemDto>>
    {
        public QueryParams QueryParams { get; set; }
    }
}
