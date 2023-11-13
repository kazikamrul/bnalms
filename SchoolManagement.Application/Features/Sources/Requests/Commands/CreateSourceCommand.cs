using MediatR;
using SchoolManagement.Application.DTOs.Source;
using SchoolManagement.Application.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.Sources.Requests.Commands
{
    public class CreateSourceCommand : IRequest<BaseCommandResponse>
    {
        public CreateSourceDto SourceDto { get; set; }
    }
}
