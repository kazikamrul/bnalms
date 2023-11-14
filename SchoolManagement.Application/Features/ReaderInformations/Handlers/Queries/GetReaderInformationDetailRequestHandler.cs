using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.ReaderInformation;
using SchoolManagement.Application.Features.ReaderInformations.Requests.Queries;
using SchoolManagement.Domain;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.ReaderInformations.Handlers.Queries
{
    public class GetReaderInformationDetailRequestHandler : IRequestHandler<GetReaderInformationDetailRequest, ReaderInformationDto>
    {
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<ReaderInformation> _ReaderInformationRepository;
        public GetReaderInformationDetailRequestHandler(ISchoolManagementRepository<ReaderInformation> ReaderInformationRepository, IMapper mapper)
        {
            _ReaderInformationRepository = ReaderInformationRepository;
            _mapper = mapper;
        }
        public async Task<ReaderInformationDto> Handle(GetReaderInformationDetailRequest request, CancellationToken cancellationToken)
        {
            var ReaderInformation = await _ReaderInformationRepository.Get(request.ReaderInformationId);
            return _mapper.Map<ReaderInformationDto>(ReaderInformation);
        }
    }
}
