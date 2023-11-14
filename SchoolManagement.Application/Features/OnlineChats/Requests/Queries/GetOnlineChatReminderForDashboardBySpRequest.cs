using MediatR;

namespace SchoolManagement.Application.Features.OnlineChats.Requests.Queries
{
    public class GetOnlineChatReminderForDashboardBySpRequest : IRequest<object>
    {
        //public int? BaseSchoolNameId { get; set; }
        public string? UserRole { get; set; }
        public int? ReceiverId { get; set; }
    }
}
