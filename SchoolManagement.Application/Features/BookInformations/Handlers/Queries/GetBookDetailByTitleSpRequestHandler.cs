using SchoolManagement.Application.Contracts.Persistence;
using MediatR;
using AutoMapper;
using SchoolManagement.Domain;
using SchoolManagement.Application.Features.BookInformations.Requests.Queries;
using System.Data;

namespace SchoolManagement.Application.Features.BookInformations.Handlers.Queries
{
    public class GetBookDetailByTitleSpRequestHandler : IRequestHandler<GetBookDetailByTitleSpRequest, object>
    {

        private readonly ISchoolManagementRepository<BookInformation> _bookinfoRepository;

        private readonly IMapper _mapper;

        public GetBookDetailByTitleSpRequestHandler(ISchoolManagementRepository<BookInformation> bookinfoRepository, IMapper mapper)
        {
            _bookinfoRepository = bookinfoRepository;
            _mapper = mapper;
        }

        public async Task<object> Handle(GetBookDetailByTitleSpRequest request, CancellationToken cancellationToken)
        {
            // object obj = new object();
            var spQuery = String.Format("exec [spGetBookDetailByTitle] {0},{1}", request.BaseSchoolNameId, request.BookTitleInfoId);

            DataTable dataTable = _bookinfoRepository.ExecWithSqlQuery(spQuery);

            return dataTable;

        }
    }
}
