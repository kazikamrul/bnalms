using MediatR;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.DTOs.FeeCategory;
using SchoolManagement.Application.Models;

namespace SchoolManagement.Application.Features.FeeCategorys.Requests.Queries
{
    public class GetFeeCategoryListRequest : IRequest<PagedResult<FeeCategoryDto>>
    {
        public QueryParams QueryParams { get; set; }
    }
}
