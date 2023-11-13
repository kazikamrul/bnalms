using MediatR;

namespace SchoolManagement.Application.Features.BookInformations.Requests.Queries
{
    public class GetBookDetailByTitleSpRequest : IRequest<object>
    {
        public int BaseSchoolNameId { get; set; }
        public int BookTitleInfoId { get; set; }
    }
}
   