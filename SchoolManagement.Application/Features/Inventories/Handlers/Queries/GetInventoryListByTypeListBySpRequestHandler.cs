using SchoolManagement.Application.Contracts.Persistence;
using MediatR;
using AutoMapper;
using SchoolManagement.Domain;
using SchoolManagement.Application.Features.Inventorys.Requests.Queries;
using System.Data;

namespace SchoolManagement.Application.Features.Inventorys.Handlers.Queries
{
    public class GetInventoryListByTypeListBySpRequestHandler : IRequestHandler<GetInventoryListByTypeListBySpRequest, object>
    {

        private readonly ISchoolManagementRepository<OnlineChat> _studentInfoByTraineeIdRepository;

        private readonly IMapper _mapper;

        public GetInventoryListByTypeListBySpRequestHandler(ISchoolManagementRepository<OnlineChat> studentInfoByTraineeIdRepository, IMapper mapper)
        {
            _studentInfoByTraineeIdRepository = studentInfoByTraineeIdRepository;
            _mapper = mapper;
        }

        public async Task<object> Handle(GetInventoryListByTypeListBySpRequest request, CancellationToken cancellationToken)
        {
           // object obj = new object();
            var spQuery = String.Format("exec [spGetInventoryListByType] {0},{1}", request.BaseSchoolNameId, request.InventoryTypeId);
            
            DataTable dataTable = _studentInfoByTraineeIdRepository.ExecWithSqlQuery(spQuery);
           
            return dataTable;
         
        }
    }
}
