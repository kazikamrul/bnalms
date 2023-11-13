using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.BookIssueAndSubmission;
using SchoolManagement.Application.Features.BookIssueAndSubmissions.Requests.Queries;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.BookIssueAndSubmissions.Handlers.Queries
{
    public class GetBookIssueAndSubmissionDetailRequestHandler : IRequestHandler<GetBookIssueAndSubmissionDetailRequest, BookIssueAndSubmissionDto>
    {
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<BookIssueAndSubmission> _BookIssueAndSubmissionRepository;
        public GetBookIssueAndSubmissionDetailRequestHandler(ISchoolManagementRepository<BookIssueAndSubmission> BookIssueAndSubmissionRepository, IMapper mapper)
        {
            _BookIssueAndSubmissionRepository = BookIssueAndSubmissionRepository;
            _mapper = mapper;
        }
        public async Task<BookIssueAndSubmissionDto> Handle(GetBookIssueAndSubmissionDetailRequest request, CancellationToken cancellationToken)
        {
            var BookIssueAndSubmission = _BookIssueAndSubmissionRepository.FinedOneInclude(x=>x.BookIssueAndSubmissionId == request.BookIssueAndSubmissionId, "BaseSchoolName", "BookInformation","BookInformation.BookTitleInfo", "MemberInfo", "RowInfo", "ShelfInfo");
            return _mapper.Map<BookIssueAndSubmissionDto>(BookIssueAndSubmission);
        }
    }
}
