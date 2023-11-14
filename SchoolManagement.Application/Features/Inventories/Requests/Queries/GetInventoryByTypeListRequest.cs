using MediatR;
using SchoolManagement.Application.DTOs.Inventorys;

namespace SchoolManagement.Application.Features.Inventorys.Requests.Queries
{
    public class GetInventoryByTypeListRequest : IRequest<List<InventoryDto>>
    {
        public int? BaseSchoolNameId { get; set; }
        //public string? UserRole { get; set; }
    }
}
