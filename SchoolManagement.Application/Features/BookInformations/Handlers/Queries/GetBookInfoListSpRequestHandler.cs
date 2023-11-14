using SchoolManagement.Application.Contracts.Persistence;
using MediatR;
using AutoMapper;
using SchoolManagement.Domain;
using SchoolManagement.Application.Features.Demands.Requests.Queries;
using System.Data;

namespace SchoolManagement.Application.Features.Demands.Handlers.Queries
{
    public class GetPendingDemandSpRequestHandler : IRequestHandler<GetBookInfoListSpRequest, object>
    {

        private readonly ISchoolManagementRepository<BookInformation> _studentInfoByTraineeIdRepository;

        private readonly IMapper _mapper;

        public GetPendingDemandSpRequestHandler(ISchoolManagementRepository<BookInformation> studentInfoByTraineeIdRepository, IMapper mapper)
        {
            _studentInfoByTraineeIdRepository = studentInfoByTraineeIdRepository;
            _mapper = mapper;
        }

        public async Task<object> Handle(GetBookInfoListSpRequest request, CancellationToken cancellationToken)
        {
           // object obj = new object();
            var spQuery = String.Format("exec [spGetBookAllBookList] {0}", request.BaseSchoolNameId);

            DataTable dataTable = _studentInfoByTraineeIdRepository.ExecWithSqlQuery(spQuery);
           
            return dataTable;
         
        }
    }
}
