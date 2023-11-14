using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.DamageInformationByLibrary;
using SchoolManagement.Application.Features.DamageInformationByLibrarys.Requests.Queries;
using SchoolManagement.Domain;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.DamageInformationByLibrarys.Handlers.Queries
{
    public class GetDamageInformationByLibraryDetailRequestHandler : IRequestHandler<GetDamageInformationByLibraryDetailRequest, DamageInformationByLibraryDto>
    {
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<DamageInformationByLibrary> _DamageInformationByLibraryRepository;
        public GetDamageInformationByLibraryDetailRequestHandler(ISchoolManagementRepository<DamageInformationByLibrary> DamageInformationByLibraryRepository, IMapper mapper)
        {
            _DamageInformationByLibraryRepository = DamageInformationByLibraryRepository;
            _mapper = mapper;
        }
        public async Task<DamageInformationByLibraryDto> Handle(GetDamageInformationByLibraryDetailRequest request, CancellationToken cancellationToken)
        {
            //var DamageInformationByLibrary = await _DamageInformationByLibraryRepository.Get(request.DamageInformationByLibraryId);
            //return _mapper.Map<DamageInformationByLibraryDto>(DamageInformationByLibrary);
            var DamageInformationByLibrary = _DamageInformationByLibraryRepository.FinedOneInclude(x => x.DamageInformationByLibraryId == request.DamageInformationByLibraryId, "BookInformation");
            return _mapper.Map<DamageInformationByLibraryDto>(DamageInformationByLibrary);
        }
    }
    
}
