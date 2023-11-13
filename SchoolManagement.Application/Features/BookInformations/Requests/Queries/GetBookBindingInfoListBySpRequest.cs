using MediatR;

namespace SchoolManagement.Application.Features.BookInformations.Requests.Queries
{
    public class GetBookBindingInfoListBySpRequest : IRequest<object>
    {
        public int BaseSchoolNameId { get; set; }
        public string SearchText { get; set; }
    }
}
   