using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.InventoryTypes.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.InventoryTypes.Handlers.Queries
{
    public class GetSelectedInventoryTypeRequestHandler : IRequestHandler<GetSelectedInventoryTypeRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<InventoryType> _InventoryTypeRepository;


        public GetSelectedInventoryTypeRequestHandler(ISchoolManagementRepository<InventoryType> InventoryTypeRepository)
        {
            _InventoryTypeRepository = InventoryTypeRepository;
        }

        public async Task<List<SelectedModel>> Handle(GetSelectedInventoryTypeRequest request, CancellationToken cancellationToken)
        {
            ICollection<InventoryType> codeValues = await _InventoryTypeRepository.FilterAsync(x => x.IsActive);
            List<SelectedModel> selectModels = codeValues.Select(x => new SelectedModel
            {
                Text = x.Name,
                Value = x.InventoryTypeId
            }).ToList();
            return selectModels;
        }
    }
}
