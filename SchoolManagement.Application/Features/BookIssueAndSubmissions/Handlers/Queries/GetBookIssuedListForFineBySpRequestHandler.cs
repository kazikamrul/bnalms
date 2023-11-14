using SchoolManagement.Application.Contracts.Persistence;
using MediatR;
using AutoMapper;
using SchoolManagement.Domain;
using SchoolManagement.Application.Features.BookIssueAndSubmissions.Requests.Queries;
using System.Data;

namespace SchoolManagement.Application.Features.BookIssueAndSubmissions.Handlers.Queries
{
    public class GetBookIssuedListForFineBySpRequestHandler : IRequestHandler<GetBookIssuedListForFineBySpRequest, object>
    {

        private readonly ISchoolManagementRepository<BookIssueAndSubmission> _bookissueRepository;

        private readonly IMapper _mapper;
          
        public GetBookIssuedListForFineBySpRequestHandler(ISchoolManagementRepository<BookIssueAndSubmission> bookissueRepository, IMapper mapper)
        {
            _bookissueRepository = bookissueRepository;
            _mapper = mapper;
        }

        public async Task<object> Handle(GetBookIssuedListForFineBySpRequest request, CancellationToken cancellationToken)
        {
            // object obj = new object();
            var spQuery = String.Format("exec [spGetBookIssueAndSubmissionListForFine] {0},{1},'{2}'", request.MemberInfoId,request.BaseSchoolNameId,request.SearchText);

            DataTable dataTable = _bookissueRepository.ExecWithSqlQuery(spQuery);

            return dataTable;

        }
    }
}
