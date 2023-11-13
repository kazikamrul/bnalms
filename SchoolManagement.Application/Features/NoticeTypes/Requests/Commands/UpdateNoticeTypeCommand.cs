using MediatR;
using SchoolManagement.Application.DTOs.NoticeType;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.NoticeTypes.Requests.Commands
{
    public class UpdateNoticeTypeCommand : IRequest<Unit>
    {
        public NoticeTypeDto NoticeTypeDto { get; set; }
    }
}
