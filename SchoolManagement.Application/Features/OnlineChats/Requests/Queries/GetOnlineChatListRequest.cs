using MediatR;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.DTOs.OnlineChat;
using SchoolManagement.Application.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.OnlineChats.Requests.Queries
{
   public class GetOnlineChatListRequest : IRequest<PagedResult<OnlineChatDto>>
    {
        public QueryParams QueryParams { get; set; }
    }
}
