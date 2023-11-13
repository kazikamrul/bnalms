using MediatR;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.DTOs.MemberCategory;
using SchoolManagement.Application.Models;

namespace SchoolManagement.Application.Features.MemberCategorys.Requests.Queries
{
    public class GetMemberCategoryListRequest : IRequest<PagedResult<MemberCategoryDto>>
    {
        public QueryParams QueryParams { get; set; }
    }
}
