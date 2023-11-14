using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.RowInfos.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.RowInfos.Handlers.Queries
{
    public class GetSelectedRowInfoRequestHandler : IRequestHandler<GetSelectedRowInfoRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<RowInfo> _RowInfoRepository;


        public GetSelectedRowInfoRequestHandler(ISchoolManagementRepository<RowInfo> RowInfoRepository)
        {
            _RowInfoRepository = RowInfoRepository;
        }

        public async Task<List<SelectedModel>> Handle(GetSelectedRowInfoRequest request, CancellationToken cancellationToken)
        {
            ICollection<RowInfo> codeValues = await _RowInfoRepository.FilterAsync(x => x.IsActive);
            List<SelectedModel> selectModels = codeValues.Select(x => new SelectedModel
            {
                Text = x.RowName,
                Value = x.RowInfoId
            }).ToList();
            return selectModels;
        }
    }
}
