using MediatR;

namespace SchoolManagement.Application.Features.BookInformations.Requests.Queries
{
    public class GetBookInformationListForMemberBySpRequest : IRequest<object>
    {
        public int MemberInfoId { get; set; }
        public int BaseSchoolNameId { get; set; }
        public string  SearchText { get; set; }
        public int BookCategoryId { get; set; }
        public int BookTitleInfoId { get; set; }
    }
} 
  