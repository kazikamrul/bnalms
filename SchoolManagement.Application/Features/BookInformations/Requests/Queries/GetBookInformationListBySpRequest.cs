using MediatR;

namespace SchoolManagement.Application.Features.BookInformations.Requests.Queries
{
    public class GetBookInformationListBySpRequest : IRequest<object>
    {
        public int BaseSchoolNameId { get; set; }
        public string  SearchText { get; set; }
        public int BookCategoryId { get; set; }
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
    }
}
  