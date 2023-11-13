using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.SupplierInformation;
using SchoolManagement.Application.Features.SupplierInformations.Requests.Queries;
using SchoolManagement.Domain;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.SupplierInformations.Handlers.Queries
{
    public class GetSupplierInformationDetailRequestHandler : IRequestHandler<GetSupplierInformationDetailRequest, SupplierInformationDto>
    {
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<SupplierInformation> _SupplierInformationRepository;
        public GetSupplierInformationDetailRequestHandler(ISchoolManagementRepository<SupplierInformation> SupplierInformationRepository, IMapper mapper)
        {
            _SupplierInformationRepository = SupplierInformationRepository;
            _mapper = mapper;
        }
        public async Task<SupplierInformationDto> Handle(GetSupplierInformationDetailRequest request, CancellationToken cancellationToken)
        {
            var SupplierInformation = await _SupplierInformationRepository.Get(request.SupplierInformationId);
            return _mapper.Map<SupplierInformationDto>(SupplierInformation);
        }
    }
}
