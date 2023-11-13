using MediatR;
using SchoolManagement.Shared.Models;
using System.Collections.Generic;

namespace SchoolManagement.Application.Features.JobStatuses.Requests.Queries
{
    public class GetSelectedJobStatusRequest : IRequest<List<SelectedModel>>
    {
    }
}
