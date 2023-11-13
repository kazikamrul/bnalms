using MediatR;
using SchoolManagement.Application.DTOs.OnlineChat;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.OnlineChats.Requests.Commands
{
    public class UpdateOnlineChatCommand : IRequest<Unit>
    {
        public OnlineChatDto OnlineChatDto { get; set; }
    }
}
