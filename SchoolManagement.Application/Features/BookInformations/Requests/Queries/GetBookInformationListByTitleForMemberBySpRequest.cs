using MediatR;

namespace SchoolManagement.Application.Features.BookInformations.Requests.Queries
{
    public class GetBookInformationListByTitleForMemberBySpRequest : IRequest<object>
    {
        //public int BaseSchoolNameId { get; set; }
        public string SearchText { get; set; }
        //public int BookCategoryId { get; set; }
    }
}
   