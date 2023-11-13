using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Domain;
using SchoolManagement.Application.DTOs.BookIssueAndSubmission;
using SchoolManagement.Application.Features.BookIssueAndSubmissions.Requests.Queries;

namespace SchoolManagement.Application.Features.BookIssueAndSubmissions.Handlers.Queries
{
    public class GetBookIssueListByMemberInfoIdRequestHandler : IRequestHandler<GetBookIssueListByMemberInfoIdRequest, List<BookIssueAndSubmissionDto>>
    {
        private readonly ISchoolManagementRepository<BookIssueAndSubmission> _BookIssueAndSubmissionRepository;

        private readonly IMapper _mapper;
        public GetBookIssueListByMemberInfoIdRequestHandler(ISchoolManagementRepository<BookIssueAndSubmission> BookIssueAndSubmissionRepository, IMapper mapper)
        {
            _BookIssueAndSubmissionRepository = BookIssueAndSubmissionRepository;
            _mapper = mapper;
        }

        public async Task<List<BookIssueAndSubmissionDto>> Handle(GetBookIssueListByMemberInfoIdRequest request, CancellationToken cancellationToken)
        {
            IQueryable<BookIssueAndSubmission> BookIssueAndSubmissions = _BookIssueAndSubmissionRepository.FilterWithInclude(x => x.MemberInfoId == request.MemberInfoId && x.ReturnStatus == 0, "MemberInfo", "BookInformation.BookTitleInfo", "BookInformation", "BookInformation.BookCategory", "BaseSchoolName");
            var totalCount = BookIssueAndSubmissions.Count();
            BookIssueAndSubmissions = BookIssueAndSubmissions.OrderByDescending(x => x.BookIssueAndSubmissionId);
            var BookIssueAndSubmissionDtos = _mapper.Map<List<BookIssueAndSubmissionDto>>(BookIssueAndSubmissions);

            return BookIssueAndSubmissionDtos;
        }

    }
}
