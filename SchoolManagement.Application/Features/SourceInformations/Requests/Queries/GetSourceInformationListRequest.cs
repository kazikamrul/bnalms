using MediatR;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.DTOs.SourceInformation;
using SchoolManagement.Application.Models;

namespace SchoolManagement.Application.Features.SourceInformations.Requests.Queries
{
    public class GetSourceInformationListRequest : IRequest<PagedResult<SourceInformationDto>>
    {
        public QueryParams QueryParams { get; set; }
        public int BookInformationId { get; set; }
    }
}
