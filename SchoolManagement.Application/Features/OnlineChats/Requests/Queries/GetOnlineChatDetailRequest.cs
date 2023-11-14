using MediatR;
using SchoolManagement.Application.DTOs.OnlineChat;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.OnlineChats.Requests.Queries
{
    public class GetOnlineChatDetailRequest : IRequest<OnlineChatDto>
    {
        public int OnlineChatId { get; set; }
    }
}
