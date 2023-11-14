using MediatR;
using SchoolManagement.Application.DTOs.OnlineChat;
using SchoolManagement.Application.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.OnlineChats.Requests.Commands
{
    public class CreateOnlineChatCommand : IRequest<BaseCommandResponse>
    {
        public CreateOnlineChatDto OnlineChatDto { get; set; }
    }
}
