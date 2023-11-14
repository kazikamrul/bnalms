using MediatR;
using SchoolManagement.Application.DTOs.JobStatus;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.JobStatuses.Requests.Queries
{
    public class GetJobStatusDetailRequest : IRequest<JobStatusDto>
    {
        public int JobStatusId { get; set; }
    }
}
