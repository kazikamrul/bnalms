using MediatR;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.DTOs.InformationFezup;
using SchoolManagement.Application.Models;

namespace SchoolManagement.Application.Features.InformationFezups.Requests.Queries
{
    public class GetInformationFezupListRequest : IRequest<PagedResult<InformationFezupDto>>
    {
        public QueryParams QueryParams { get; set; }
    }
}
