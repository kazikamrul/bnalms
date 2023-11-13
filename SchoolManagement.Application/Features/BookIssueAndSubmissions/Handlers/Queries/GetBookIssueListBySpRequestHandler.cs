using SchoolManagement.Application.Contracts.Persistence;
using MediatR;
using AutoMapper;
using SchoolManagement.Domain;
using SchoolManagement.Application.Features.BookIssueAndSubmissions.Requests.Queries;
using System.Data;

namespace SchoolManagement.Application.Features.BookIssueAndSubmissions.Handlers.Queries
{
    public class GetBookIssueListBySpRequestHandler : IRequestHandler<GetBookIssueListBySpRequest, object>
    {

        private readonly ISchoolManagementRepository<BookIssueAndSubmission> _bookissueRepository;

        private readonly IMapper _mapper;
          
        public GetBookIssueListBySpRequestHandler(ISchoolManagementRepository<BookIssueAndSubmission> bookissueRepository, IMapper mapper)
        {
            _bookissueRepository = bookissueRepository;
            _mapper = mapper;
        }

        public async Task<object> Handle(GetBookIssueListBySpRequest request, CancellationToken cancellationToken)
        {
            // object obj = new object();
            var spQuery = String.Format("exec [spGetBookIssueList] {0},'{1}'", request.BaseSchoolNameId,request.SearchText);

            DataTable dataTable = _bookissueRepository.ExecWithSqlQuery(spQuery);

            return dataTable;

        }
    }
}
