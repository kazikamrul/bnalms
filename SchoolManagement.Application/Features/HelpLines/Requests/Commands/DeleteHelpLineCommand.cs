using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.HelpLines.Requests.Commands
{
    public class DeleteHelpLineCommand : IRequest
    {
        public int HelpLineId { get; set; }
    }
}
