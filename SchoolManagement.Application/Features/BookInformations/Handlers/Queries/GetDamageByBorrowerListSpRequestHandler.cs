using SchoolManagement.Application.Contracts.Persistence;
using MediatR;
using AutoMapper;
using SchoolManagement.Domain;
using SchoolManagement.Application.Features.BookInformations.Requests.Queries;
using System.Data;

namespace SchoolManagement.Application.Features.BookInformations.Handlers.Queries
{
    public class GetDamageByBorrowerListSpRequestHandler : IRequestHandler<GetDamageByBorrowerListSpRequest, object>
    {

        private readonly ISchoolManagementRepository<BookInformation> _bookinfoRepository;

        private readonly IMapper _mapper;

        public GetDamageByBorrowerListSpRequestHandler(ISchoolManagementRepository<BookInformation> bookinfoRepository, IMapper mapper)
        {
            _bookinfoRepository = bookinfoRepository;
            _mapper = mapper;
        }

        public async Task<object> Handle(GetDamageByBorrowerListSpRequest request, CancellationToken cancellationToken)
        {
            // object obj = new object();
            var spQuery = String.Format("exec [spGetDamageByBorrowerList] {0},'{1}'", request.BaseSchoolNameId,request.SearchText);

            DataTable dataTable = _bookinfoRepository.ExecWithSqlQuery(spQuery);

            return dataTable;

        }
    }
}
