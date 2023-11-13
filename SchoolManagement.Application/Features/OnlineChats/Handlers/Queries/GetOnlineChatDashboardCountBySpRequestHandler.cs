using SchoolManagement.Application.Contracts.Persistence;
using MediatR;
using AutoMapper;
using SchoolManagement.Domain;
using SchoolManagement.Application.Features.OnlineChats.Requests.Queries;
using System.Data;

namespace SchoolManagement.Application.Features.OnlineChats.Handlers.Queries
{
    public class GetOnlineChatDashboardCountBySpRequestHandler : IRequestHandler<GetOnlineChatDashboardCountBySpRequest, object>
    {

        private readonly ISchoolManagementRepository<OnlineChat> _studentInfoByTraineeIdRepository;

        private readonly IMapper _mapper;

        public GetOnlineChatDashboardCountBySpRequestHandler(ISchoolManagementRepository<OnlineChat> studentInfoByTraineeIdRepository, IMapper mapper)
        {
            _studentInfoByTraineeIdRepository = studentInfoByTraineeIdRepository;
            _mapper = mapper;
        }

        public async Task<object> Handle(GetOnlineChatDashboardCountBySpRequest request, CancellationToken cancellationToken)
        {
           // object obj = new object();
            var spQuery = String.Format("exec [spGetOnlineChatDashboardCount] {0},'{1}'", request.BaseSchoolNameId, request.UserRole);
            
            DataTable dataTable = _studentInfoByTraineeIdRepository.ExecWithSqlQuery(spQuery);
           
            return dataTable;
         
        }
    }
}
