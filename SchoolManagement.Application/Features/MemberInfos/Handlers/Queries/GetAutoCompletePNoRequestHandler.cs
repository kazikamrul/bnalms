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
    public class GetAutoCompletePNoRequestHandler : IRequestHandler<GetAutoCompletePNoRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<MemberInfo> _MemberInfoRepository; 
        public GetAutoCompletePNoRequestHandler(ISchoolManagementRepository<MemberInfo> MemberInfoRepository)
        {
            _MemberInfoRepository = MemberInfoRepository;
        }
          
        public async Task<List<SelectedModel>> Handle(GetAutoCompletePNoRequest request, CancellationToken cancellationToken)
        {
                ICollection<MemberInfo> traineeBioDataGeneralInfos = await _MemberInfoRepository.FilterAsync(x => x.IsActive && x.PNO.Contains(request.Pno));
                var selectModels = traineeBioDataGeneralInfos.Select(x => new SelectedModel
                { 
                    Text = x.MemberName+'-'+x.PNO,
                    Value = x.MemberInfoId
                }).ToList();
                return selectModels;
            }
      }
}
