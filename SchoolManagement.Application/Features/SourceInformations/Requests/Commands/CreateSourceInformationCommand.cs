using MediatR;
using SchoolManagement.Application.DTOs.SourceInformation;
using SchoolManagement.Application.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.SourceInformations.Requests.Commands
{
    public class CreateSourceInformationCommand : IRequest<BaseCommandResponse>
    {
        public CreateSourceInformationDto SourceInformationDto { get; set; }
    }
}
