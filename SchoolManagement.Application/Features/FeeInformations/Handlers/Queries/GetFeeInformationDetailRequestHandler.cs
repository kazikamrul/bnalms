using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.FeeInformation;
using SchoolManagement.Application.Features.FeeInformations.Requests.Queries;
using SchoolManagement.Domain;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.FeeInformations.Handlers.Queries
{
    public class GetFeeInformationDetailRequestHandler : IRequestHandler<GetFeeInformationDetailRequest, FeeInformationDto>
    {
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<FeeInformation> _FeeInformationRepository;
        public GetFeeInformationDetailRequestHandler(ISchoolManagementRepository<FeeInformation> FeeInformationRepository, IMapper mapper)
        {
            _FeeInformationRepository = FeeInformationRepository;
            _mapper = mapper;
        }
        public async Task<FeeInformationDto> Handle(GetFeeInformationDetailRequest request, CancellationToken cancellationToken)
        {
            //var FeeInformation = await _FeeInformationRepository.Get(request.FeeInformationId);
            //return _mapper.Map<FeeInformationDto>(FeeInformation);
            var FeeInformation = _FeeInformationRepository.FinedOneInclude(x => x.FeeInformationId == request.FeeInformationId, "MemberInfo");
            return _mapper.Map<FeeInformationDto>(FeeInformation);
        }
    }
}
