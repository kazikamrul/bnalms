using MediatR;

namespace SchoolManagement.Application.Features.Demands.Requests.Queries
{
    public class GetOnlineBookRequestCountByMemberAndLibraryBySpRequest : IRequest<object>
    {
        public int BaseSchoolNameId { get; set; }
        public int MemberInfoId { get; set; }
    } 
} 
  
   