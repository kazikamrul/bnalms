using MediatR;
using SchoolManagement.Application.DTOs.OnlineChat;

namespace SchoolManagement.Application.Features.OnlineChats.Requests.Queries
{
    public class GetOnlineChatsByIdRequest : IRequest<List<OnlineChatDto>>
    {        
        public string? UserRole { get; set; }
        public int? SenderId { get; set; }
        public int? ReciverId { get; set; }
    }
}

 