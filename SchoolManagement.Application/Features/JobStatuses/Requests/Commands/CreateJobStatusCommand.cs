using MediatR;
using SchoolManagement.Application.DTOs.JobStatus;
using SchoolManagement.Application.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.JobStatuses.Requests.Commands
{
    public class CreateJobStatusCommand : IRequest<BaseCommandResponse>
    {
        public CreateJobStatusDto JobStatusDto { get; set; }
    }
}
