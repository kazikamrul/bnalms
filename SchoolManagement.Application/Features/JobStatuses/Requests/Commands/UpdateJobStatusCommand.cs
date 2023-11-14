using MediatR;
using SchoolManagement.Application.DTOs.JobStatus;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.JobStatuses.Requests.Commands
{
    public class UpdateJobStatusCommand : IRequest<Unit>
    {
        public JobStatusDto JobStatusDto { get; set; }
    }
}
