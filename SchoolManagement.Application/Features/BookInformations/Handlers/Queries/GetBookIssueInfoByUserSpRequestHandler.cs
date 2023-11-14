using SchoolManagement.Application.Contracts.Persistence;
using MediatR;
using AutoMapper;
using SchoolManagement.Domain;
using SchoolManagement.Application.Features.BookInformations.Requests.Queries;
using System.Data;

namespace SchoolManagement.Application.Features.BookInformations.Handlers.Queries
{
    public class GetBookIssueInfoByUserSpRequestHandler : IRequestHandler<GetBookIssueInfoByUserSpRequest, object>
    {

        private readonly ISchoolManagementRepository<BookInformation> _studentInfoByTraineeIdRepository;

        private readonly IMapper _mapper;

        public GetBookIssueInfoByUserSpRequestHandler(ISchoolManagementRepository<BookInformation> studentInfoByTraineeIdRepository, IMapper mapper)
        {
            _studentInfoByTraineeIdRepository = studentInfoByTraineeIdRepository;
            _mapper = mapper;
        }

        public async Task<object> Handle(GetBookIssueInfoByUserSpRequest request, CancellationToken cancellationToken)
        {
           // object obj = new object();
            var spQuery = String.Format("exec [spUserInfoByBookInformation] {0}", request.BookInformationId);

            DataTable dataTable = _studentInfoByTraineeIdRepository.ExecWithSqlQuery(spQuery);
           
            return dataTable;
         
        }
    }
}
