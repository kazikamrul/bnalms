using MediatR;
using SchoolManagement.Application.DTOs.Source;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.Sources.Requests.Commands
{
    public class UpdateSourceCommand : IRequest<Unit>
    {
        public SourceDto SourceDto { get; set; }
    }
}
