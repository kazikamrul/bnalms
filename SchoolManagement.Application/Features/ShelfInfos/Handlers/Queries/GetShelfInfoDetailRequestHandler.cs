using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.ShelfInfo;
using SchoolManagement.Application.Features.ShelfInfos.Requests.Queries;
using SchoolManagement.Domain;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.ShelfInfos.Handlers.Queries
{
    public class GetShelfInfoDetailRequestHandler : IRequestHandler<GetShelfInfoDetailRequest, ShelfInfoDto>
    {
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<ShelfInfo> _ShelfInfoRepository;
        public GetShelfInfoDetailRequestHandler(ISchoolManagementRepository<ShelfInfo> ShelfInfoRepository, IMapper mapper)
        {
            _ShelfInfoRepository = ShelfInfoRepository;
            _mapper = mapper;
        }
        public async Task<ShelfInfoDto> Handle(GetShelfInfoDetailRequest request, CancellationToken cancellationToken)
        {
            var ShelfInfo = await _ShelfInfoRepository.Get(request.ShelfInfoId);
            return _mapper.Map<ShelfInfoDto>(ShelfInfo);
        }
    }
}
