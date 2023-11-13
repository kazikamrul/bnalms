using MediatR;

namespace SchoolManagement.Application.Features.Bulletins.Requests.Queries
{
    public class GetBulletinListByLibrarySpRequest : IRequest<object>
    {
        public int BaseSchoolNameId { get; set; }
    }
}
