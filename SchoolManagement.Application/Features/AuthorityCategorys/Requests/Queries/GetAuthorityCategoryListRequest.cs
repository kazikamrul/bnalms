using MediatR;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.DTOs.AuthorityCategory;
using SchoolManagement.Application.Models;

namespace SchoolManagement.Application.Features.AuthorityCategorys.Requests.Queries
{
    public class GetAuthorityCategoryListRequest : IRequest<PagedResult<AuthorityCategoryDto>>
    {
        public QueryParams QueryParams { get; set; }
    }
}
