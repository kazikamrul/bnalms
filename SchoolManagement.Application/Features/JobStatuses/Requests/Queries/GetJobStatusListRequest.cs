using MediatR;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.DTOs.JobStatus;
using SchoolManagement.Application.Models;

namespace SchoolManagement.Application.Features.JobStatuses.Requests.Queries
{
    public class GetJobStatusListRequest : IRequest<PagedResult<JobStatusDto>>
    {
        public QueryParams QueryParams { get; set; }
    }
}
