using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.EventInfo;
using SchoolManagement.Application.Features.EventInfos.Requests.Queries;
using SchoolManagement.Domain;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.EventInfos.Handlers.Queries
{
    public class GetEventInfoDetailRequestHandler : IRequestHandler<GetEventInfoDetailRequest, EventInfoDto>
    {
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<EventInfo> _EventInfoRepository;
        public GetEventInfoDetailRequestHandler(ISchoolManagementRepository<EventInfo> EventInfoRepository, IMapper mapper)
        {
            _EventInfoRepository = EventInfoRepository;
            _mapper = mapper;
        }
        public async Task<EventInfoDto> Handle(GetEventInfoDetailRequest request, CancellationToken cancellationToken)
        {
            var EventInfo = await _EventInfoRepository.Get(request.EventInfoId);
            return _mapper.Map<EventInfoDto>(EventInfo);
        }
    }
}
