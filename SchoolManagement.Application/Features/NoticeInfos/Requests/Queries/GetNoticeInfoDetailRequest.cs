using MediatR;
using SchoolManagement.Application.DTOs.NoticeInfo;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.NoticeInfos.Requests.Queries
{
    public class GetNoticeInfoDetailRequest : IRequest<NoticeInfoDto>
    {
        public int NoticeInfoId { get; set; }
    }
}
