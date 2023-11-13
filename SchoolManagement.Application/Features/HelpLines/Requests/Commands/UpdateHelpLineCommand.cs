using MediatR;
using SchoolManagement.Application.DTOs.HelpLine;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.HelpLines.Requests.Commands
{
    public class UpdateHelpLineCommand : IRequest<Unit>
    {
        public HelpLineDto HelpLineDto { get; set; }
    }
}
