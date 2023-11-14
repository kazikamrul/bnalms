using MediatR;
using SchoolManagement.Application.DTOs.NoticeInfo;
using SchoolManagement.Application.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.NoticeInfos.Requests.Commands
{
    public class CreateNoticeInfoCommand : IRequest<BaseCommandResponse>
    {
        public CreateNoticeInfoDto NoticeInfoDto { get; set; }
    }
}
