using MediatR;
using SchoolManagement.Application.DTOs.EventInfo;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.EventInfos.Requests.Queries
{
    public class GetEventInfoDetailRequest : IRequest<EventInfoDto>
    {
        public int EventInfoId { get; set; }
    }
}
