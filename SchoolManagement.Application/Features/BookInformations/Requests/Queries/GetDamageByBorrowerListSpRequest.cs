using MediatR;

namespace SchoolManagement.Application.Features.BookInformations.Requests.Queries
{
    public class GetDamageByBorrowerListSpRequest : IRequest<object>
    {
        public int BaseSchoolNameId { get; set; }
        public string  SearchText { get; set; }
    }
}
   