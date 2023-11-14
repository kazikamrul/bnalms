using MediatR;

namespace SchoolManagement.Application.Features.Inventorys.Requests.Queries
{
    public class GetInventoryByTypeListBySpRequest : IRequest<object>
    {
        public int? BaseSchoolNameId { get; set; }
        //public string? UserRole { get; set; }
    }
}
