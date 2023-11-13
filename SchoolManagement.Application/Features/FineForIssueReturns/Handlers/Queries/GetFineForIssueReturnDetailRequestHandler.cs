using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.FineForIssueReturns;
using SchoolManagement.Application.Features.FineForIssueReturns.Requests.Queries;
using SchoolManagement.Domain;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.FineForIssueReturns.Handlers.Queries
{
    public class GetFineForIssueReturnDetailRequestHandler : IRequestHandler<GetFineForIssueReturnDetailRequest, FineForIssueReturnDto>
    {
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<FineForIssueReturn> _FineForIssueReturnRepository;
        public GetFineForIssueReturnDetailRequestHandler(ISchoolManagementRepository<FineForIssueReturn> FineForIssueReturnRepository, IMapper mapper)
        {
            _FineForIssueReturnRepository = FineForIssueReturnRepository;
            _mapper = mapper;
        }
        public async Task<FineForIssueReturnDto> Handle(GetFineForIssueReturnDetailRequest request, CancellationToken cancellationToken)
        {
            var FineForIssueReturn = await _FineForIssueReturnRepository.Get(request.FineForIssueReturnId);
            return _mapper.Map<FineForIssueReturnDto>(FineForIssueReturn);
        }
    }
}
