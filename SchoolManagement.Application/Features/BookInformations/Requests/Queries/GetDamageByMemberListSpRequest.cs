using MediatR;

namespace SchoolManagement.Application.Features.BookInformations.Requests.Queries
{
    public class GetDamageByMemberListSpRequest : IRequest<object>
    {
        public int MemberInfoId { get; set; }
    }
}
   