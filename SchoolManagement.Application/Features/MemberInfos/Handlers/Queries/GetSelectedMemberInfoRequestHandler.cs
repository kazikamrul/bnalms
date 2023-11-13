using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.MemberInfos.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.MemberInfos.Handlers.Queries
{
    public class GetSelectedMemberInfoRequestHandler : IRequestHandler<GetSelectedMemberInfoRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<MemberInfo> _MemberInfoRepository;


        public GetSelectedMemberInfoRequestHandler(ISchoolManagementRepository<MemberInfo> MemberInfoRepository)
        {
            _MemberInfoRepository = MemberInfoRepository;
        }

        public async Task<List<SelectedModel>> Handle(GetSelectedMemberInfoRequest request, CancellationToken cancellationToken)
        {
            ICollection<MemberInfo> codeValues = await _MemberInfoRepository.FilterAsync(x => x.IsActive);
            List<SelectedModel> selectModels = codeValues.Select(x => new SelectedModel
            {
                Text = x.MemberName,
                Value = x.MemberInfoId
            }).ToList();
            return selectModels;
        }
    }
}
