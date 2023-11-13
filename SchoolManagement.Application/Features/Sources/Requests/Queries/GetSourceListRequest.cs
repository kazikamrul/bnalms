using MediatR;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.DTOs.Source;
using SchoolManagement.Application.Models;

namespace SchoolManagement.Application.Features.Sources.Requests.Queries
{
    public class GetSourceListRequest : IRequest<PagedResult<SourceDto>>
    {
        public QueryParams QueryParams { get; set; }
    }
}
