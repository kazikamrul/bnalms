using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.Base;
using SchoolManagement.Application.Features.Bases.Requests.Queries;
using SchoolManagement.Domain;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.Bases.Handlers.Queries
{
    public class GetBaseDetailRequestHandler : IRequestHandler<GetBaseDetailRequest, BasemDto>
    {
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<Base> _BaseRepository;
        public GetBaseDetailRequestHandler(ISchoolManagementRepository<Base> BaseRepository, IMapper mapper)
        {
            _BaseRepository = BaseRepository;
            _mapper = mapper;
        }
        public async Task<BasemDto> Handle(GetBaseDetailRequest request, CancellationToken cancellationToken)
        {
            var Base = await _BaseRepository.Get(request.BaseId);
            return _mapper.Map<BasemDto>(Base);
        }
    }
}
