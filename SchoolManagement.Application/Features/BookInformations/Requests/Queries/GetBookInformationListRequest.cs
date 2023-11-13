using MediatR;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.DTOs.BookInformation;
using SchoolManagement.Application.Models;

namespace SchoolManagement.Application.Features.BookInformations.Requests.Queries
{
    public class GetBookInformationListRequest : IRequest<PagedResult<BookInformationDto>>
    {
        public QueryParams QueryParams { get; set; }
    }
}
