using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.NoticeInfos.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.NoticeInfos.Handlers.Queries
{
    public class GetSelectedNoticeInfoRequestHandler : IRequestHandler<GetSelectedNoticeInfoRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<NoticeInfo> _NoticeInfoRepository;


        public GetSelectedNoticeInfoRequestHandler(ISchoolManagementRepository<NoticeInfo> NoticeInfoRepository)
        {
            _NoticeInfoRepository = NoticeInfoRepository;
        }

        public async Task<List<SelectedModel>> Handle(GetSelectedNoticeInfoRequest request, CancellationToken cancellationToken)
        {
            ICollection<NoticeInfo> codeValues = await _NoticeInfoRepository.FilterAsync(x => x.IsActive);
            List<SelectedModel> selectModels = codeValues.Select(x => new SelectedModel
            {
                Text = x.NoticeTitle,
                Value = x.NoticeInfoId
            }).ToList();
            return selectModels;
        }
    }
}
