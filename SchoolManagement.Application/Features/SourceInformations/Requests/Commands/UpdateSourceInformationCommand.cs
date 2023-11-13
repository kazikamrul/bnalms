using MediatR;
using SchoolManagement.Application.DTOs.SourceInformation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.SourceInformations.Requests.Commands
{
    public class UpdateSourceInformationCommand : IRequest<Unit>
    {
        public SourceInformationDto SourceInformationDto { get; set; }
    }
}
