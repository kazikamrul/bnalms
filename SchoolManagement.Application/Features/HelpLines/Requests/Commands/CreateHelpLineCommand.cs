using MediatR;
using SchoolManagement.Application.DTOs.HelpLine;
using SchoolManagement.Application.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.HelpLines.Requests.Commands
{
    public class CreateHelpLineCommand : IRequest<BaseCommandResponse>
    {
        public CreateHelpLineDto HelpLineDto { get; set; }
    }
}
