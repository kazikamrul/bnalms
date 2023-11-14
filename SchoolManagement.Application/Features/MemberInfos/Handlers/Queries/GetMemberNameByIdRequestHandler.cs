using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.MemberInfos.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.MemberInfos.Handlers.Queries
{
    public class GetMemberNameByIdRequestHandler : IRequestHandler<GetMemberNameByIdRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<MemberInfo> _MemberInfoRepository;


        public GetMemberNameByIdRequestHandler(ISchoolManagementRepository<MemberInfo> MemberInfoRepository)
        {
            _MemberInfoRepository = MemberInfoRepository;
        }

        public async Task<List<SelectedModel>> Handle(GetMemberNameByIdRequest request, CancellationToken cancellationToken)
        {
            var MemberInfos = _MemberInfoRepository.FilterWithInclude(x => x.IsActive && x.MemberInfoId == request.MemberInfoId).ToList();
           

            List<SelectedModel> selectModels = MemberInfos.Select(x => new SelectedModel
            {
                Text = x.MemberInfoId,
                Value = x.MemberName
            }).ToList();
            return selectModels;
        }
    }
}
