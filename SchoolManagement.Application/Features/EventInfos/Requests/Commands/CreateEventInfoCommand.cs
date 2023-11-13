using MediatR;
using SchoolManagement.Application.DTOs.EventInfo;
using SchoolManagement.Application.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.EventInfos.Requests.Commands
{
    public class CreateEventInfoCommand : IRequest<BaseCommandResponse>
    {
        public CreateEventInfoDto EventInfoDto { get; set; }
    }
}
