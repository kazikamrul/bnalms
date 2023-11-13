using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.MemberInfo;
using SchoolManagement.Application.Features.MemberInfos.Requests.Queries;
using SchoolManagement.Domain;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.MemberInfos.Handlers.Queries
{
    public class GetMemberInfoDetailRequestHandler : IRequestHandler<GetMemberInfoDetailRequest, MemberInfoDto>
    {
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<MemberInfo> _MemberInfoRepository;
        public GetMemberInfoDetailRequestHandler(ISchoolManagementRepository<MemberInfo> MemberInfoRepository, IMapper mapper)
        {
            _MemberInfoRepository = MemberInfoRepository;
            _mapper = mapper;
        }
        public async Task<MemberInfoDto> Handle(GetMemberInfoDetailRequest request, CancellationToken cancellationToken)
        {
            //var MemberInfo = await _MemberInfoRepository.Get(request.MemberInfoId);
            //return _mapper.Map<MemberInfoDto>(MemberInfo);
            var MemberInfo = _MemberInfoRepository.FinedOneInclude(x => x.MemberInfoId == request.MemberInfoId, "BaseSchoolName", "MemberCategory", "Rank", "Designation", "JobStatus");
            return _mapper.Map<MemberInfoDto>(MemberInfo);
        }
    }
}
