using MediatR;
using SchoolManagement.Application.DTOs.PublishersInformation;
using SchoolManagement.Application.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.PublishersInformations.Requests.Commands
{
    public class CreatePublishersInformationCommand : IRequest<BaseCommandResponse>
    {
        public CreatePublishersInformationDto PublishersInformationDto { get; set; }
    }
}
