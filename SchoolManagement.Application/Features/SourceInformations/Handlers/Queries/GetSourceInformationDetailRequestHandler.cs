using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.SourceInformation;
using SchoolManagement.Application.Features.SourceInformations.Requests.Queries;
using SchoolManagement.Domain;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.SourceInformations.Handlers.Queries
{
    public class GetSourceInformationDetailRequestHandler : IRequestHandler<GetSourceInformationDetailRequest, SourceInformationDto>
    {
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<SourceInformation> _SourceInformationRepository;
        public GetSourceInformationDetailRequestHandler(ISchoolManagementRepository<SourceInformation> SourceInformationRepository, IMapper mapper)
        {
            _SourceInformationRepository = SourceInformationRepository;
            _mapper = mapper;
        }
        public async Task<SourceInformationDto> Handle(GetSourceInformationDetailRequest request, CancellationToken cancellationToken)
        {
            var SourceInformation = await _SourceInformationRepository.Get(request.SourceInformationId);
            return _mapper.Map<SourceInformationDto>(SourceInformation);
        }
    }
}
