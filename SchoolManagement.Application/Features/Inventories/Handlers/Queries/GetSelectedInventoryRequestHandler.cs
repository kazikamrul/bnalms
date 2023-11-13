using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.Inventorys.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.Inventorys.Handlers.Queries
{
    public class GetSelectedInventoryRequestHandler : IRequestHandler<GetSelectedInventoryRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<Inventory> _InventoryRepository;


        public GetSelectedInventoryRequestHandler(ISchoolManagementRepository<Inventory> InventoryRepository)
        {
            _InventoryRepository = InventoryRepository;
        }

        public async Task<List<SelectedModel>> Handle(GetSelectedInventoryRequest request, CancellationToken cancellationToken)
        {
            ICollection<Inventory> codeValues = await _InventoryRepository.FilterAsync(x => x.IsActive);
            List<SelectedModel> selectModels = codeValues.Select(x => new SelectedModel
            {
                Text = x.CompanyName,
                Value = x.InventoryId
            }).ToList();
            return selectModels;
        }
    }
}
