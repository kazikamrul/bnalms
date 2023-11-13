using MediatR;

namespace SchoolManagement.Application.Features.OnlineChats.Requests.Queries
{
    public class GetOnlineChatResponseListForSchoolBySpRequest : IRequest<object>
    {
        public int? BaseSchoolNameId { get; set; }
    }
}
