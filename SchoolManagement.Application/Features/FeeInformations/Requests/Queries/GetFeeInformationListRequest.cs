using MediatR;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.DTOs.FeeInformation;
using SchoolManagement.Application.Models;

namespace SchoolManagement.Application.Features.FeeInformations.Requests.Queries
{
    public class GetFeeInformationListRequest : IRequest<PagedResult<FeeInformationDto>>
    {
        public QueryParams QueryParams { get; set; }
    }
}
