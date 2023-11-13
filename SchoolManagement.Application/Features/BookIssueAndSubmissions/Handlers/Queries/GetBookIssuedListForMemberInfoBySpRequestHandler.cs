using SchoolManagement.Application.Contracts.Persistence;
using MediatR;
using AutoMapper;
using SchoolManagement.Domain;
using SchoolManagement.Application.Features.BookIssueAndSubmissions.Requests.Queries;
using System.Data;

namespace SchoolManagement.Application.Features.BookIssueAndSubmissions.Handlers.Queries
{
    public class GetBookIssuedListForMemberInfoBySpRequestHandler : IRequestHandler<GetBookIssuedListForMemberInfoBySpRequest, object>
    {

        private readonly ISchoolManagementRepository<BookIssueAndSubmission> _bookissueRepository;

        private readonly IMapper _mapper;
          
        public GetBookIssuedListForMemberInfoBySpRequestHandler(ISchoolManagementRepository<BookIssueAndSubmission> bookissueRepository, IMapper mapper)
        {
            _bookissueRepository = bookissueRepository;
            _mapper = mapper;
        }

        public async Task<object> Handle(GetBookIssuedListForMemberInfoBySpRequest request, CancellationToken cancellationToken)
        {
            // object obj = new object();
            var spQuery = String.Format("exec [spGetBookIssuedListForMemberInfo] {0},'{1}'", request.MemberInfoId, request.SearchText);

            DataTable dataTable = _bookissueRepository.ExecWithSqlQuery(spQuery);

            return dataTable;

        }
    }
}
