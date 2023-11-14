using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.NoticeTypes.Requests.Commands
{
    public class DeleteNoticeTypeCommand : IRequest
    {
        public int NoticeTypeId { get; set; }
    }
}
