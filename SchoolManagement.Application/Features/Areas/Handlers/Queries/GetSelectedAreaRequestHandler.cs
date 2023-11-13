using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.Areas.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.Areas.Handlers.Queries
{
    public class GetSelectedAreaRequestHandler : IRequestHandler<GetSelectedAreaRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<Area> _AreaRepository;


        public GetSelectedAreaRequestHandler(ISchoolManagementRepository<Area> AreaRepository)
        {
            _AreaRepository = AreaRepository;
        }

        public async Task<List<SelectedModel>> Handle(GetSelectedAreaRequest request, CancellationToken cancellationToken)
        {
            ICollection<Area> codeValues = await _AreaRepository.FilterAsync(x => x.IsActive);
            List<SelectedModel> selectModels = codeValues.Select(x => new SelectedModel
            {
                Text = x.Name,
                Value = x.AreaId
            }).ToList();
            return selectModels;
        }
    }
}
