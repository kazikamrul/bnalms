using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.Sources.Requests.Commands
{
    public class DeleteSourceCommand : IRequest
    {
        public int SourceId { get; set; }
    }
}
