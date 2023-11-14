using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.NoticeTypes.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.NoticeTypes.Handlers.Queries
{
    public class GetSelectedNoticeTypeRequestHandler : IRequestHandler<GetSelectedNoticeTypeRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<NoticeType> _NoticeTypeRepository;


        public GetSelectedNoticeTypeRequestHandler(ISchoolManagementRepository<NoticeType> NoticeTypeRepository)
        {
            _NoticeTypeRepository = NoticeTypeRepository;
        }

        public async Task<List<SelectedModel>> Handle(GetSelectedNoticeTypeRequest request, CancellationToken cancellationToken)
        {
            ICollection<NoticeType> codeValues = await _NoticeTypeRepository.FilterAsync(x => x.IsActive);
            List<SelectedModel> selectModels = codeValues.OrderByDescending(x=>x.MenuPosition).Select(x => new SelectedModel
            {
                Text = x.Name,
                Value = x.NoticeTypeId
            }).ToList();
            return selectModels;
        }
    }
}
