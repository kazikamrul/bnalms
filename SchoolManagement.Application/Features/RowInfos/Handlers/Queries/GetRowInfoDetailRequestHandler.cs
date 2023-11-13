using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.RowInfo;
using SchoolManagement.Application.Features.RowInfos.Requests.Queries;
using SchoolManagement.Domain;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.RowInfos.Handlers.Queries
{
    public class GetRowInfoDetailRequestHandler : IRequestHandler<GetRowInfoDetailRequest, RowInfoDto>
    {
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<RowInfo> _RowInfoRepository;
        public GetRowInfoDetailRequestHandler(ISchoolManagementRepository<RowInfo> RowInfoRepository, IMapper mapper)
        {
            _RowInfoRepository = RowInfoRepository;
            _mapper = mapper;
        }
        public async Task<RowInfoDto> Handle(GetRowInfoDetailRequest request, CancellationToken cancellationToken)
        {
            var RowInfo = await _RowInfoRepository.Get(request.RowInfoId);
            return _mapper.Map<RowInfoDto>(RowInfo);
        }
    }
}
