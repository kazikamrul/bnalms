using AutoMapper;
using SchoolManagement.Application.DTOs.BookIssueAndSubmission;
using SchoolManagement.Application.Features.BookIssueAndSubmissions.Requests.Queries;
using SchoolManagement.Application.Contracts.Persistence;
using MediatR;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.BookIssueAndSubmissions.Handlers.Queries   
{
    public class GetBookIssueAndSubmissionListByUserRequestHandler : IRequestHandler<GetBookIssueAndSubmissionListByUserRequest, List<BookIssueAndSubmissionDto>>
    {

        private readonly ISchoolManagementRepository<BookIssueAndSubmission> _BookIssueAndSubmissionRepository;

        private readonly IMapper _mapper;

        public GetBookIssueAndSubmissionListByUserRequestHandler(ISchoolManagementRepository<BookIssueAndSubmission> BookIssueAndSubmissionRepository, IMapper mapper)
        {
            _BookIssueAndSubmissionRepository = BookIssueAndSubmissionRepository;
            _mapper = mapper;
        }

        public async Task<List<BookIssueAndSubmissionDto>> Handle(GetBookIssueAndSubmissionListByUserRequest request, CancellationToken cancellationToken)
        {
            IQueryable<BookIssueAndSubmission> BookIssueAndSubmissions = _BookIssueAndSubmissionRepository.FilterWithInclude(x => x.MemberInfoId == request.MemberInfoId && x.ReturnStatus == 0 && x.BorrowerDamageStatus == 0, "MemberInfo", "BookInformation.BookTitleInfo", "BookInformation");
            //var BaseSchoolNames = _BaseSchoolNameRepository.Where(x => x.BaseSchoolNameId == request.BaseSchoolNameId && x.CourseNameId == request.CourseNameId && x.CourseModuleId == request.CourseModuleId && x.Status == request.Status).OrderByDescending(x => x.BaseSchoolNameId);

            var BookIssueAndSubmissionDtos = _mapper.Map<List<BookIssueAndSubmissionDto>>(BookIssueAndSubmissions);

            return BookIssueAndSubmissionDtos;
        }
    }
}
