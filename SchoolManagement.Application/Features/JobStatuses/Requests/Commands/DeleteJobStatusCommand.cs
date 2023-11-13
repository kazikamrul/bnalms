using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.JobStatuses.Requests.Commands
{
    public class DeleteJobStatusCommand : IRequest
    {
        public int JobStatusId { get; set; }
    }
}
