using SchoolManagement.Application.Contracts.Persistence;
using MediatR;
using AutoMapper;
using SchoolManagement.Domain;
using SchoolManagement.Application.Features.BookInformations.Requests.Queries;
using System.Data;

namespace SchoolManagement.Application.Features.BookInformations.Handlers.Queries
{
    public class GetBookInformationListByTitleForMemberBySpRequestHandler : IRequestHandler<GetBookInformationListByTitleForMemberBySpRequest, object>
    {

        private readonly ISchoolManagementRepository<BookInformation> _studentInfoByTraineeIdRepository;

        private readonly IMapper _mapper;

        public GetBookInformationListByTitleForMemberBySpRequestHandler(ISchoolManagementRepository<BookInformation> studentInfoByTraineeIdRepository, IMapper mapper)
        {
            _studentInfoByTraineeIdRepository = studentInfoByTraineeIdRepository;
            _mapper = mapper;
        }

        public async Task<object> Handle(GetBookInformationListByTitleForMemberBySpRequest request, CancellationToken cancellationToken)
        {
            // object obj = new object();
            var spQuery = String.Format("exec [spGetBookListByTitleMember] '{0}'", request.SearchText);

            DataTable dataTable = _studentInfoByTraineeIdRepository.ExecWithSqlQuery(spQuery);

            return dataTable;

        }
    }
}
