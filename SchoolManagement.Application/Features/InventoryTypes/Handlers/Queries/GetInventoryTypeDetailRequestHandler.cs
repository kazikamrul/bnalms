using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.InventoryTypes;
using SchoolManagement.Application.Features.InventoryTypes.Requests.Queries;
using SchoolManagement.Domain;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.InventoryTypes.Handlers.Queries
{
    public class GetInventoryTypeDetailRequestHandler : IRequestHandler<GetInventoryTypeDetailRequest, InventoryTypeDto>
    {
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<InventoryType> _InventoryTypeRepository;
        public GetInventoryTypeDetailRequestHandler(ISchoolManagementRepository<InventoryType> InventoryTypeRepository, IMapper mapper)
        {
            _InventoryTypeRepository = InventoryTypeRepository;
            _mapper = mapper;
        }
        public async Task<InventoryTypeDto> Handle(GetInventoryTypeDetailRequest request, CancellationToken cancellationToken)
        {
            var InventoryType = await _InventoryTypeRepository.Get(request.InventoryTypeId);
            return _mapper.Map<InventoryTypeDto>(InventoryType);
        }
    }
}
