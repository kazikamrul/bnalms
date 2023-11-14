using SchoolManagement.Application.Contracts.Persistence;
using MediatR;
using AutoMapper;
using SchoolManagement.Domain;
using SchoolManagement.Application.Features.Inventorys.Requests.Queries;
using System.Data;

namespace SchoolManagement.Application.Features.Inventorys.Handlers.Queries
{
    public class GetInventoryByTypeListBySpRequestHandler : IRequestHandler<GetInventoryByTypeListBySpRequest, object>
    {

        private readonly ISchoolManagementRepository<OnlineChat> _studentInfoByTraineeIdRepository;

        private readonly IMapper _mapper;

        public GetInventoryByTypeListBySpRequestHandler(ISchoolManagementRepository<OnlineChat> studentInfoByTraineeIdRepository, IMapper mapper)
        {
            _studentInfoByTraineeIdRepository = studentInfoByTraineeIdRepository;
            _mapper = mapper;
        }

        public async Task<object> Handle(GetInventoryByTypeListBySpRequest request, CancellationToken cancellationToken)
        {
           // object obj = new object();
            var spQuery = String.Format("exec [spGetInventoryDetailsForDashboard] {0}", request.BaseSchoolNameId);
            
            DataTable dataTable = _studentInfoByTraineeIdRepository.ExecWithSqlQuery(spQuery);
           
            return dataTable;
         
        }
    }
}
