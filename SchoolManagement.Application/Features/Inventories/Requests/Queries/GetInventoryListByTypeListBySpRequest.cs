using MediatR;

namespace SchoolManagement.Application.Features.Inventorys.Requests.Queries
{
    public class GetInventoryListByTypeListBySpRequest : IRequest<object>
    {
        public int? BaseSchoolNameId { get; set; }
        public int? InventoryTypeId { get; set; }
        //public string? UserRole { get; set; }
    }
}
