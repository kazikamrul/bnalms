using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.Inventorys;
using SchoolManagement.Application.Features.Inventorys.Requests.Queries;
using SchoolManagement.Domain;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.Inventorys.Handlers.Queries
{
    public class GetInventoryDetailRequestHandler : IRequestHandler<GetInventoryDetailRequest, InventoryDto>
    {
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<Inventory> _InventoryRepository;
        public GetInventoryDetailRequestHandler(ISchoolManagementRepository<Inventory> InventoryRepository, IMapper mapper)
        {
            _InventoryRepository = InventoryRepository;
            _mapper = mapper;
        }
        public async Task<InventoryDto> Handle(GetInventoryDetailRequest request, CancellationToken cancellationToken)
        {
            var Inventory = await _InventoryRepository.Get(request.InventoryId);
            return _mapper.Map<InventoryDto>(Inventory);
        }
    }
}
