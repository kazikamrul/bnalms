using SchoolManagement.Application.Contracts.Persistence;
using MediatR;
using AutoMapper;
using SchoolManagement.Domain;
using SchoolManagement.Application.Features.BookInformations.Requests.Queries;
using System.Data;

namespace SchoolManagement.Application.Features.BookInformations.Handlers.Queries
{
    public class GetSpDamageByBorrowerDateRangeRequestHandler : IRequestHandler<GetSpDamageByBorrowerDateRangeRequest, object>
    {

        private readonly ISchoolManagementRepository<BookInformation> _bookInformationRepository;

        private readonly IMapper _mapper;

        public GetSpDamageByBorrowerDateRangeRequestHandler(ISchoolManagementRepository<BookInformation> bookInformationRepository, IMapper mapper)
        {
            _bookInformationRepository = bookInformationRepository;
            _mapper = mapper;
        }

        public async Task<object> Handle(GetSpDamageByBorrowerDateRangeRequest request, CancellationToken cancellationToken)
        {
           // object obj = new object();
            var spQuery = String.Format("exec [spGetDamageByBorrowerByDateRange] '{0}','{1}',{2}", request.DateFrom, request.DateTo, request.BaseSchoolNameId);

            DataTable dataTable = _bookInformationRepository.ExecWithSqlQuery(spQuery);
           
            return dataTable;
         
        }
    }
}
