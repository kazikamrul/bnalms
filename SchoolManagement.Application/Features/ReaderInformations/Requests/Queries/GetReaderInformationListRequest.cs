using MediatR;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.DTOs.ReaderInformation;
using SchoolManagement.Application.Models;

namespace SchoolManagement.Application.Features.ReaderInformations.Requests.Queries
{
    public class GetReaderInformationListRequest : IRequest<PagedResult<ReaderInformationDto>>
    {
        public QueryParams QueryParams { get; set; }
    }
}
