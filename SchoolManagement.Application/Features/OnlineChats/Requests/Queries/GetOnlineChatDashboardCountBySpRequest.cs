using MediatR;

namespace SchoolManagement.Application.Features.OnlineChats.Requests.Queries
{
    public class GetOnlineChatDashboardCountBySpRequest : IRequest<object>
    {
        public int? BaseSchoolNameId { get; set; }
        public string? UserRole { get; set; }
    }
}
