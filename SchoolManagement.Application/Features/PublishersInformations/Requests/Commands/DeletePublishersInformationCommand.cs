using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.PublishersInformations.Requests.Commands
{
    public class DeletePublishersInformationCommand : IRequest
    {
        public int PublishersInformationId { get; set; }
    }
}
