using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Domain;
using SchoolManagement.Application.DTOs.FeeInformation;
using SchoolManagement.Application.Features.FeeInformations.Requests.Queries;

namespace SchoolManagement.Application.Features.FeeInformations.Handlers.Queries
{
    public class GetFeeInformationListByPnoRequestHandler : IRequestHandler<GetFeeInformationListByPnoRequest, List<FeeInformationDto>>
    {
        private readonly ISchoolManagementRepository<FeeInformation> _FeeInformationRepository;

        private readonly IMapper _mapper;
        public GetFeeInformationListByPnoRequestHandler(ISchoolManagementRepository<FeeInformation> FeeInformationRepository, IMapper mapper)
        {
            _FeeInformationRepository = FeeInformationRepository;
            _mapper = mapper;
        }

        public async Task<List<FeeInformationDto>> Handle(GetFeeInformationListByPnoRequest request, CancellationToken cancellationToken)
        {
            IQueryable<FeeInformation> FeeInformations = _FeeInformationRepository.FilterWithInclude(x => x.MemberInfoId == request.MemberInfoId  , "MemberInfo", "FeeCategory", "BookInformation");
            var totalCount = FeeInformations.Count();
            FeeInformations = FeeInformations.OrderByDescending(x => x.ExpiredDate);
            var FeeInformationDtos = _mapper.Map<List<FeeInformationDto>>(FeeInformations);

            return FeeInformationDtos;
        }

    }
}
