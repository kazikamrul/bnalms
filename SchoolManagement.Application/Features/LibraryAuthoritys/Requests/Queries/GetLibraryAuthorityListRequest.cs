using MediatR;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.DTOs.LibraryAuthority;
using SchoolManagement.Application.Models;

namespace SchoolManagement.Application.Features.LibraryAuthoritys.Requests.Queries
{
    public class GetLibraryAuthorityListRequest : IRequest<PagedResult<LibraryAuthorityDto>>
    {
        public QueryParams QueryParams { get; set; }
    }
}
