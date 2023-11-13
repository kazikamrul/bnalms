using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Domain;
using SchoolManagement.Application.DTOs.HelpLine;
using SchoolManagement.Application.Features.HelpLines.Requests.Queries;

namespace SchoolManagement.Application.Features.HelpLines.Handlers.Queries
{
    public class GetHelpLineListByDepartmentIdRequestHandler : IRequestHandler<GetHelpLineListByDepartmentIdRequest, List<HelpLineDto>>
    {
        private readonly ISchoolManagementRepository<HelpLine> _HelpLineRepository;

        private readonly IMapper _mapper;
        public GetHelpLineListByDepartmentIdRequestHandler(ISchoolManagementRepository<HelpLine> HelpLineRepository, IMapper mapper)
        {
            _HelpLineRepository = HelpLineRepository;
            _mapper = mapper;
        }

        public async Task<List<HelpLineDto>> Handle(GetHelpLineListByDepartmentIdRequest request, CancellationToken cancellationToken)
        {
            IQueryable<HelpLine> HelpLines = _HelpLineRepository.FilterWithInclude(x => x.BaseSchoolNameId == (request.BaseSchoolNameId != 0 ? request.BaseSchoolNameId : x.BaseSchoolNameId), "BaseSchoolName", "LibraryAuthority");
            var totalCount = HelpLines.Count();
            HelpLines = HelpLines.OrderByDescending(x => x.HelpLineId);
            var HelpLineDtos = _mapper.Map<List<HelpLineDto>>(HelpLines);

            return HelpLineDtos;
        }

    }
}
