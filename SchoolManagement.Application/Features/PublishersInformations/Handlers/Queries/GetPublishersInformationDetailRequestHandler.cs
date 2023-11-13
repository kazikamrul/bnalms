using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.PublishersInformation;
using SchoolManagement.Application.Features.PublishersInformations.Requests.Queries;
using SchoolManagement.Domain;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.PublishersInformations.Handlers.Queries
{
    public class GetPublishersInformationDetailRequestHandler : IRequestHandler<GetPublishersInformationDetailRequest, PublishersInformationDto>
    {
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<PublishersInformation> _PublishersInformationRepository;
        public GetPublishersInformationDetailRequestHandler(ISchoolManagementRepository<PublishersInformation> PublishersInformationRepository, IMapper mapper)
        {
            _PublishersInformationRepository = PublishersInformationRepository;
            _mapper = mapper;
        }
        public async Task<PublishersInformationDto> Handle(GetPublishersInformationDetailRequest request, CancellationToken cancellationToken)
        {
            var PublishersInformation = await _PublishersInformationRepository.Get(request.PublishersInformationId);
            return _mapper.Map<PublishersInformationDto>(PublishersInformation);
        }
    }
}
