using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.SourceInformations.Requests.Commands
{
    public class DeleteSourceInformationCommand : IRequest
    {
        public int SourceInformationId { get; set; }
    }
}
