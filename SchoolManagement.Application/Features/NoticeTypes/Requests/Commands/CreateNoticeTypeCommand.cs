using MediatR;
using SchoolManagement.Application.DTOs.NoticeType;
using SchoolManagement.Application.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.NoticeTypes.Requests.Commands
{
    public class CreateNoticeTypeCommand : IRequest<BaseCommandResponse>
    {
        public CreateNoticeTypeDto NoticeTypeDto { get; set; }
    }
}
