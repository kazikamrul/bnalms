using MediatR;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.DTOs.SupplierInformation;
using SchoolManagement.Application.Models;

namespace SchoolManagement.Application.Features.SupplierInformations.Requests.Queries
{
    public class GetSupplierInformationListRequest : IRequest<PagedResult<SupplierInformationDto>>
    {
        public QueryParams QueryParams { get; set; }
        public int BookInformationId { get; set; }
    }
}
