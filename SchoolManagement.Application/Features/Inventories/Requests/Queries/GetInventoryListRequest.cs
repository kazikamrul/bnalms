using MediatR;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.DTOs.Inventorys;
using SchoolManagement.Application.Models;

namespace SchoolManagement.Application.Features.Inventorys.Requests.Queries
{
    public class GetInventoryListRequest : IRequest<PagedResult<InventoryDto>>
    {
        public QueryParams QueryParams { get; set; }
        public int InventoryTypeId { get; set; }
        public int BaseSchoolNameId { get; set; }
    }
}
