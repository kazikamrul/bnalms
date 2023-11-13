using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.NoticeInfos.Requests.Commands
{
    public class DeleteNoticeInfoCommand : IRequest
    {
        public int NoticeInfoId { get; set; }
    }
}
