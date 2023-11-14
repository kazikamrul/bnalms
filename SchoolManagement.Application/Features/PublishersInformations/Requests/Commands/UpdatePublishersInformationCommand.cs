using MediatR;
using SchoolManagement.Application.DTOs.PublishersInformation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.PublishersInformations.Requests.Commands
{
    public class UpdatePublishersInformationCommand : IRequest<Unit>
    {
        public PublishersInformationDto PublishersInformationDto { get; set; }
    }
}
