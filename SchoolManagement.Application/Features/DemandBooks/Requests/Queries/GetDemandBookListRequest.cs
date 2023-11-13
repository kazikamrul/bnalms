using MediatR;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.DTOs.DemandBook;
using SchoolManagement.Application.Models;

namespace SchoolManagement.Application.Features.DemandBooks.Requests.Queries
{
    public class GetDemandBookListRequest : IRequest<PagedResult<DemandBookDto>>
    {
        public QueryParams QueryParams { get; set; }
    }
}
