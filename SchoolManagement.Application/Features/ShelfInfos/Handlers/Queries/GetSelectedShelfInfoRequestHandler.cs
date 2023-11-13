using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.ShelfInfos.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.ShelfInfos.Handlers.Queries
{
    public class GetSelectedShelfInfoRequestHandler : IRequestHandler<GetSelectedShelfInfoRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<ShelfInfo> _ShelfInfoRepository;


        public GetSelectedShelfInfoRequestHandler(ISchoolManagementRepository<ShelfInfo> ShelfInfoRepository)
        {
            _ShelfInfoRepository = ShelfInfoRepository;
        }

        public async Task<List<SelectedModel>> Handle(GetSelectedShelfInfoRequest request, CancellationToken cancellationToken)
        {
            ICollection<ShelfInfo> codeValues = await _ShelfInfoRepository.FilterAsync(x => x.IsActive);
            List<SelectedModel> selectModels = codeValues.Select(x => new SelectedModel
            {
                Text = x.ShelfName,
                Value = x.ShelfInfoId
            }).ToList();
            return selectModels;
        }
    }
}
