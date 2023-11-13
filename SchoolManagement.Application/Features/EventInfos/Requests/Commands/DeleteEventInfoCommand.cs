using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.EventInfos.Requests.Commands
{
    public class DeleteEventInfoCommand : IRequest
    {
        public int EventInfoId { get; set; }
    }
}
