using SchoolManagement.Application.Contracts.Persistence;
using MediatR;
using AutoMapper;
using SchoolManagement.Domain;
using SchoolManagement.Application.Features.OnlineChats.Requests.Queries;
using System.Data;

namespace SchoolManagement.Application.Features.OnlineChats.Handlers.Queries
{
    public class GetOnlineChatReminderForAdminBySpRequestHandler : IRequestHandler<GetOnlineChatReminderForAdminBySpRequest, object>
    {

        private readonly ISchoolManagementRepository<OnlineChat> _studentInfoByTraineeIdRepository;

        private readonly IMapper _mapper;

        public GetOnlineChatReminderForAdminBySpRequestHandler(ISchoolManagementRepository<OnlineChat> studentInfoByTraineeIdRepository, IMapper mapper)
        {
            _studentInfoByTraineeIdRepository = studentInfoByTraineeIdRepository;
            _mapper = mapper;
        }

        public async Task<object> Handle(GetOnlineChatReminderForAdminBySpRequest request, CancellationToken cancellationToken)
        {
           // object obj = new object();
            var spQuery = String.Format("exec [spGetOnlineChatReminderForAdmin] {0},'{1}'", request.BaseSchoolNameId, request.UserRole);
            
            DataTable dataTable = _studentInfoByTraineeIdRepository.ExecWithSqlQuery(spQuery);
           
            return dataTable;
         
        }
    }
}
