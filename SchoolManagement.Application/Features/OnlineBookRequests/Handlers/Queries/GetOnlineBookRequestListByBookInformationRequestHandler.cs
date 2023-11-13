using AutoMapper;
using SchoolManagement.Application.DTOs.OnlineBookRequest;
using SchoolManagement.Application.Features.OnlineBookRequests.Requests.Queries;
using SchoolManagement.Application.Contracts.Persistence;
using MediatR;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.OnlineBookRequests.Handlers.Queries   
{
    public class GetOnlineBookRequestListByBookInformationRequestHandler : IRequestHandler<GetOnlineBookRequestListByBookInformationRequest, List<OnlineBookRequestDto>>
    {

        private readonly ISchoolManagementRepository<OnlineBookRequest> _OnlineBookRequestRepository;

        private readonly IMapper _mapper;

        public GetOnlineBookRequestListByBookInformationRequestHandler(ISchoolManagementRepository<OnlineBookRequest> OnlineBookRequestRepository, IMapper mapper)
        {
            _OnlineBookRequestRepository = OnlineBookRequestRepository;
            _mapper = mapper;
        }

        public async Task<List<OnlineBookRequestDto>> Handle(GetOnlineBookRequestListByBookInformationRequest request, CancellationToken cancellationToken)
        {
            IQueryable<OnlineBookRequest> OnlineBookRequests = _OnlineBookRequestRepository.FilterWithInclude(x => x.BookInformationId == request.BookInformationId && x.CancelStatus == 0 && x.IssueStatus == 0, "MemberInfo", "BookInformation.BookTitleInfo");
            //var BaseSchoolNames = _BaseSchoolNameRepository.Where(x => x.BaseSchoolNameId == request.BaseSchoolNameId && x.CourseNameId == request.CourseNameId && x.CourseModuleId == request.CourseModuleId && x.Status == request.Status).OrderByDescending(x => x.BaseSchoolNameId);

            var OnlineBookRequestDtos = _mapper.Map<List<OnlineBookRequestDto>>(OnlineBookRequests);

            return OnlineBookRequestDtos;
        }
    }
}
