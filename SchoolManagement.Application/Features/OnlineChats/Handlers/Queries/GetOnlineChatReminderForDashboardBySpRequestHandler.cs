using SchoolManagement.Application.Contracts.Persistence;
using MediatR;
using AutoMapper;
using SchoolManagement.Domain;
using SchoolManagement.Application.Features.OnlineChats.Requests.Queries;
using System.Data;

namespace SchoolManagement.Application.Features.OnlineChats.Handlers.Queries
{
    public class GetOnlineChatReminderForDashboardBySpRequestHandler : IRequestHandler<GetOnlineChatReminderForDashboardBySpRequest, object>
    {

        private readonly ISchoolManagementRepository<OnlineChat> _studentInfoByTraineeIdRepository;

        private readonly IMapper _mapper;

        public GetOnlineChatReminderForDashboardBySpRequestHandler(ISchoolManagementRepository<OnlineChat> studentInfoByTraineeIdRepository, IMapper mapper)
        {
            _studentInfoByTraineeIdRepository = studentInfoByTraineeIdRepository;
            _mapper = mapper;
        }

        public async Task<object> Handle(GetOnlineChatReminderForDashboardBySpRequest request, CancellationToken cancellationToken)
        {
           // object obj = new object();
            var spQuery = String.Format("exec [spGetOnlineChatReminderForDashboard] '{0}',{1}", request.UserRole,request.ReceiverId);
            
            DataTable dataTable = _studentInfoByTraineeIdRepository.ExecWithSqlQuery(spQuery);
           
            return dataTable;
         
        }
    }
}
