using MediatR;

namespace SchoolManagement.Application.Features.Bulletins.Requests.Queries
{
    public class GetBulletinListBySpRequest : IRequest<object>
    {
        public int MemberInfoId { get; set; }
    }
}
