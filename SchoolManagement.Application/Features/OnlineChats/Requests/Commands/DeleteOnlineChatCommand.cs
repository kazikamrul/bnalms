using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.OnlineChats.Requests.Commands
{
    public class DeleteOnlineChatCommand : IRequest
    {
        public int OnlineChatId { get; set; }
    }
}
