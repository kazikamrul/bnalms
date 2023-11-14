using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.Source;
using SchoolManagement.Application.Features.Sources.Requests.Queries;
using SchoolManagement.Domain;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.Sources.Handlers.Queries
{
    public class GetSourceDetailRequestHandler : IRequestHandler<GetSourceDetailRequest, SourceDto>
    {
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<Source> _SourceRepository;
        public GetSourceDetailRequestHandler(ISchoolManagementRepository<Source> SourceRepository, IMapper mapper)
        {
            _SourceRepository = SourceRepository;
            _mapper = mapper;
        }
        public async Task<SourceDto> Handle(GetSourceDetailRequest request, CancellationToken cancellationToken)
        {
            var Source = await _SourceRepository.Get(request.SourceId);
            return _mapper.Map<SourceDto>(Source);
        }
    }
}
