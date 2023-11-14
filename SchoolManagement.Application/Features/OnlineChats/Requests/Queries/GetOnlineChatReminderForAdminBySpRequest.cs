using MediatR;

namespace SchoolManagement.Application.Features.OnlineChats.Requests.Queries
{
    public class GetOnlineChatReminderForAdminBySpRequest : IRequest<object>
    {
        public int? BaseSchoolNameId { get; set; }
        public string? UserRole { get; set; }
    }
}
