using SchoolManagement.Application.Contracts.Persistence;
using MediatR;
using AutoMapper;
using SchoolManagement.Domain;
using SchoolManagement.Application.Features.Inventorys.Requests.Queries;
using System.Data;
using SchoolManagement.Application.DTOs.Inventorys;

namespace SchoolManagement.Application.Features.Inventorys.Handlers.Queries
{
    public class GetInventoryByTypeListRequestHandler : IRequestHandler<GetInventoryByTypeListRequest, List<InventoryDto>>
    {

        private readonly ISchoolManagementRepository<Inventory> _inventoryRepository;

        private readonly IMapper _mapper;

        public GetInventoryByTypeListRequestHandler(ISchoolManagementRepository<Inventory> inventoryRepository, IMapper mapper)
        {
            _inventoryRepository = inventoryRepository;
            _mapper = mapper;
        }

        public async Task<List<InventoryDto>> Handle(GetInventoryByTypeListRequest request, CancellationToken cancellationToken)
        {
            IQueryable<Inventory> Inventorys = _inventoryRepository.FilterWithInclude(x => x.BaseSchoolNameId == (request.BaseSchoolNameId != 0 ? request.BaseSchoolNameId : x.BaseSchoolNameId));

            var InventoryDtos = _mapper.Map<List<InventoryDto>>(Inventorys);

            return InventoryDtos;
            // object obj = new object();
            //var spQuery = String.Format("exec [spGetInventoryDetailsForDashboard] {0}", request.BaseSchoolNameId);

            //DataTable dataTable = _studentInfoByTraineeIdRepository.ExecWithSqlQuery(spQuery);

            //return dataTable;

        }
    }
}
