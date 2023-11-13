using MediatR;

namespace SchoolManagement.Application.Features.BookInformations.Requests.Queries
{
    public class GetBookListByTitleSpRequest : IRequest<object>
    {
        public int BaseSchoolNameId { get; set; }
        public int BookCategoryId { get; set; }
    }
}
   