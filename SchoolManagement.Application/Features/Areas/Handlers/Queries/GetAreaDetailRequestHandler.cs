using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.Area;
using SchoolManagement.Application.Features.Areas.Requests.Queries;
using SchoolManagement.Domain;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.Areas.Handlers.Queries
{
    public class GetAreaDetailRequestHandler : IRequestHandler<GetAreaDetailRequest, AreaDto>
    {
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<Area> _AreaRepository;
        public GetAreaDetailRequestHandler(ISchoolManagementRepository<Area> AreaRepository, IMapper mapper)
        {
            _AreaRepository = AreaRepository;
            _mapper = mapper;
        }
        public async Task<AreaDto> Handle(GetAreaDetailRequest request, CancellationToken cancellationToken)
        {
            var Area = await _AreaRepository.Get(request.AreaId);
            return _mapper.Map<AreaDto>(Area);
        }
    }
}
