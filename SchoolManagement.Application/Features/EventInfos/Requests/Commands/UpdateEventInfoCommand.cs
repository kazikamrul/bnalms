using MediatR;
using SchoolManagement.Application.DTOs.EventInfo;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.EventInfos.Requests.Commands
{
    public class UpdateEventInfoCommand : IRequest<Unit>
    {
        public EventInfoDto EventInfoDto { get; set; }
    }
}
