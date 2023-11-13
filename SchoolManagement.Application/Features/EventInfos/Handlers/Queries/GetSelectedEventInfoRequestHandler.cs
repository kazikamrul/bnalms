using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.EventInfos.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.EventInfos.Handlers.Queries
{
    public class GetSelectedEventInfoRequestHandler : IRequestHandler<GetSelectedEventInfoRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<EventInfo> _EventInfoRepository;


        public GetSelectedEventInfoRequestHandler(ISchoolManagementRepository<EventInfo> EventInfoRepository)
        {
            _EventInfoRepository = EventInfoRepository;
        }

        public async Task<List<SelectedModel>> Handle(GetSelectedEventInfoRequest request, CancellationToken cancellationToken)
        {
            ICollection<EventInfo> codeValues = await _EventInfoRepository.FilterAsync(x => x.IsActive);
            List<SelectedModel> selectModels = codeValues.Select(x => new SelectedModel
            {
                Text = x.EventName,
                Value = x.EventInfoId
            }).ToList();
            return selectModels;
        }
    }
}
