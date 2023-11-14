using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.JobStatuses.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.JobStatuses.Handlers.Queries
{
    public class GetSelectedJobStatusRequestHandler : IRequestHandler<GetSelectedJobStatusRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<JobStatus> _JobStatusRepository;


        public GetSelectedJobStatusRequestHandler(ISchoolManagementRepository<JobStatus> JobStatusRepository)
        {
            _JobStatusRepository = JobStatusRepository;
        }

        public async Task<List<SelectedModel>> Handle(GetSelectedJobStatusRequest request, CancellationToken cancellationToken)
        {
            ICollection<JobStatus> codeValues = await _JobStatusRepository.FilterAsync(x => x.IsActive);
            List<SelectedModel> selectModels = codeValues.Select(x => new SelectedModel
            {
                Text = x.JobStatusName,
                Value = x.JobStatusId
            }).ToList();
            return selectModels;
        }
    }
}
