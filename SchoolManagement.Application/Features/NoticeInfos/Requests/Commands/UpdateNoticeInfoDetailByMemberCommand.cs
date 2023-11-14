using MediatR;
using SchoolManagement.Application.DTOs.NoticeInfo;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.NoticeInfos.Requests.Commands
{
    public class UpdateNoticeInfoDetailByMemberCommand : IRequest<Unit>
    {
        public int NoticeInfoId { get; set; }
        //public CreateNoticeInfoDto CreateNoticeInfoDto { get; set; }
    }
}
