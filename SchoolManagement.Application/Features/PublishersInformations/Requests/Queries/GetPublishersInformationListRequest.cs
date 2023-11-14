using MediatR;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.DTOs.PublishersInformation;
using SchoolManagement.Application.Models;

namespace SchoolManagement.Application.Features.PublishersInformations.Requests.Queries
{
    public class GetPublishersInformationListRequest : IRequest<PagedResult<PublishersInformationDto>>
    {
        public QueryParams QueryParams { get; set; }
        public int BookInformationId { get; set; }
    }
}
