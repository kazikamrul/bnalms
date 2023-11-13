using MediatR;
using SchoolManagement.Application.DTOs.NoticeType;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.NoticeTypes.Requests.Queries
{
    public class GetNoticeTypeDetailRequest : IRequest<NoticeTypeDto>
    {
        public int NoticeTypeId { get; set; }
    }
}
