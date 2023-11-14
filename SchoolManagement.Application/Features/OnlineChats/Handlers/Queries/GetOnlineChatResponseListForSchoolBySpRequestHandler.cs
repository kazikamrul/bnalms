using SchoolManagement.Application.Contracts.Persistence;
using MediatR;
using AutoMapper;
using SchoolManagement.Domain;
using SchoolManagement.Application.Features.OnlineChats.Requests.Queries;
using System.Data;

namespace SchoolManagement.Application.Features.OnlineChats.Handlers.Queries
{
    public class GetOnlineChatResponseListForSchoolBySpRequestHandler : IRequestHandler<GetOnlineChatResponseListForSchoolBySpRequest, object>
    {

        private readonly ISchoolManagementRepository<OnlineChat> _studentInfoByTraineeIdRepository;

        private readonly IMapper _mapper;

        public GetOnlineChatResponseListForSchoolBySpRequestHandler(ISchoolManagementRepository<OnlineChat> studentInfoByTraineeIdRepository, IMapper mapper)
        {
            _studentInfoByTraineeIdRepository = studentInfoByTraineeIdRepository;
            _mapper = mapper;
        }

        public async Task<object> Handle(GetOnlineChatResponseListForSchoolBySpRequest request, CancellationToken cancellationToken)
        {
           // object obj = new object();
            var spQuery = String.Format("exec [spGetOnlineChatResponseListForLibrary] {0}", request.BaseSchoolNameId);
            
            DataTable dataTable = _studentInfoByTraineeIdRepository.ExecWithSqlQuery(spQuery);
           
            return dataTable;
         
        }
    }
}
