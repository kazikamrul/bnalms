using MediatR;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.DTOs.InventoryTypes;
using SchoolManagement.Application.Models;

namespace SchoolManagement.Application.Features.InventoryTypes.Requests.Queries
{
    public class GetInventoryTypeListRequest : IRequest<PagedResult<InventoryTypeDto>>
    {
        public QueryParams QueryParams { get; set; }
    }
}
