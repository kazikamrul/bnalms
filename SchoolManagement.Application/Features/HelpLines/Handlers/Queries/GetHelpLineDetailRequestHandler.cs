using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.HelpLine;
using SchoolManagement.Application.Features.HelpLines.Requests.Queries;
using SchoolManagement.Domain;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.HelpLines.Handlers.Queries
{
    public class GetHelpLineDetailRequestHandler : IRequestHandler<GetHelpLineDetailRequest, HelpLineDto>
    {
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<HelpLine> _HelpLineRepository;
        public GetHelpLineDetailRequestHandler(ISchoolManagementRepository<HelpLine> HelpLineRepository, IMapper mapper)
        {
            _HelpLineRepository = HelpLineRepository;
            _mapper = mapper;
        }
        public async Task<HelpLineDto> Handle(GetHelpLineDetailRequest request, CancellationToken cancellationToken)
        {
            var HelpLine = await _HelpLineRepository.Get(request.HelpLineId);
            return _mapper.Map<HelpLineDto>(HelpLine);
        }
    }
}
