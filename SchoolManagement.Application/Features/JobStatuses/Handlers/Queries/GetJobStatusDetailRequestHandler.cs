using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.JobStatus;
using SchoolManagement.Application.Features.JobStatuses.Requests.Queries;
using SchoolManagement.Domain;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.JobStatuses.Handlers.Queries
{
    public class GetJobStatusDetailRequestHandler : IRequestHandler<GetJobStatusDetailRequest, JobStatusDto>
    {
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<JobStatus> _JobStatusRepository;
        public GetJobStatusDetailRequestHandler(ISchoolManagementRepository<JobStatus> JobStatusRepository, IMapper mapper)
        {
            _JobStatusRepository = JobStatusRepository;
            _mapper = mapper;
        }
        public async Task<JobStatusDto> Handle(GetJobStatusDetailRequest request, CancellationToken cancellationToken)
        {
            var JobStatus = await _JobStatusRepository.Get(request.JobStatusId);
            return _mapper.Map<JobStatusDto>(JobStatus);
        }
    }
}
