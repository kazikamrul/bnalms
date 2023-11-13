using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Domain;
using SchoolManagement.Application.DTOs.MemberInfo;
using SchoolManagement.Application.Features.MemberInfos.Requests.Queries;

namespace SchoolManagement.Application.Features.MemberInfos.Handlers.Queries
{
    public class GetMemberInformationListByDepartmentIdRequestHandler : IRequestHandler<GetMemberInformationListByDepartmentIdRequest, List<MemberInfoDto>>
    {
        private readonly ISchoolManagementRepository<MemberInfo> _MemberInfoRepository;

        private readonly IMapper _mapper;
        public GetMemberInformationListByDepartmentIdRequestHandler(ISchoolManagementRepository<MemberInfo> MemberInfoRepository, IMapper mapper)
        {
            _MemberInfoRepository = MemberInfoRepository;
            _mapper = mapper;
        }

        public async Task<List<MemberInfoDto>> Handle(GetMemberInformationListByDepartmentIdRequest request, CancellationToken cancellationToken)
        {
            IQueryable<MemberInfo> MemberInfos = _MemberInfoRepository.FilterWithInclude(x => x.BaseSchoolNameId == request.BaseSchoolNameId  , "Rank");
            var totalCount = MemberInfos.Count();
            MemberInfos = MemberInfos.OrderByDescending(x => x.MemberInfoId);
            var MemberInfoDtos = _mapper.Map<List<MemberInfoDto>>(MemberInfos);

            return MemberInfoDtos;
        }

    }
}
