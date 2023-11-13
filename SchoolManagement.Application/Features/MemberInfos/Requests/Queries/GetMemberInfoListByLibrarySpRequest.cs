using MediatR;

namespace SchoolManagement.Application.Features.MemberInfos.Requests.Queries
{
    public class GetMemberInfoListByLibrarySpRequest : IRequest<object>
    {
        public int BaseSchoolNameId { get; set; }
        public string SearchText { get; set; }
    }
} 
  