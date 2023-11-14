using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.InformationFezup;
using SchoolManagement.Application.Features.InformationFezups.Requests.Queries;
using SchoolManagement.Domain;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.InformationFezups.Handlers.Queries
{
    public class GetInformationFezupDetailRequestHandler : IRequestHandler<GetInformationFezupDetailRequest, InformationFezupDto>
    {
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<InformationFezup> _InformationFezupRepository;
        public GetInformationFezupDetailRequestHandler(ISchoolManagementRepository<InformationFezup> InformationFezupRepository, IMapper mapper)
        {
            _InformationFezupRepository = InformationFezupRepository;
            _mapper = mapper;
        }
        public async Task<InformationFezupDto> Handle(GetInformationFezupDetailRequest request, CancellationToken cancellationToken)
        {
            var InformationFezup = await _InformationFezupRepository.Get(request.InformationFezupId);
            return _mapper.Map<InformationFezupDto>(InformationFezup);
        }
    }
}
