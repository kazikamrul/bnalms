using MediatR;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.DTOs.AuthorInformation;
using SchoolManagement.Application.Models;

namespace SchoolManagement.Application.Features.AuthorInformations.Requests.Queries
{
    public class GetAuthorInformationListRequest : IRequest<PagedResult<AuthorInformationDto>>
    {
        public QueryParams QueryParams { get; set; }
        public int BookInformationId { get; set; }
    }
}
