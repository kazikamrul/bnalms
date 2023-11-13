using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.RowInfos.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.RowInfos.Handlers.Queries
{
    public class GetRowNameByShelfInfoIdRequestHandler : IRequestHandler<GetRowNameByShelfInfoIdRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<RowInfo> _RowInfoRepository;

          
        public GetRowNameByShelfInfoIdRequestHandler(ISchoolManagementRepository<RowInfo> RowInfoRepository)
        {
            _RowInfoRepository = RowInfoRepository;           
        }

        public async Task<List<SelectedModel>> Handle(GetRowNameByShelfInfoIdRequest request, CancellationToken cancellationToken)
        {
            ICollection<RowInfo> RowInfos = await _RowInfoRepository.FilterAsync(x =>x.ShelfInfoId == request.ShelfInfoId);
            List<SelectedModel> selectModels = RowInfos.Select(x => new SelectedModel
            {
                Text = x.RowName, 
                Value = x.RowInfoId 
            }).ToList();
            return selectModels;
        }
    }
}
