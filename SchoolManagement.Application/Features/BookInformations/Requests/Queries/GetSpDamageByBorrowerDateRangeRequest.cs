using MediatR;

namespace SchoolManagement.Application.Features.BookInformations.Requests.Queries
{
    public class GetSpDamageByBorrowerDateRangeRequest : IRequest<object>
    {
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
        public int BaseSchoolNameId { get; set; } 
    }
} 
