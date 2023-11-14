using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.LibraryAuthority;
using SchoolManagement.Application.Features.LibraryAuthoritys.Requests.Queries;
using SchoolManagement.Domain;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.LibraryAuthoritys.Handlers.Queries
{
    public class GetLibraryAuthorityDetailRequestHandler : IRequestHandler<GetLibraryAuthorityDetailRequest, LibraryAuthorityDto>
    {
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<LibraryAuthority> _LibraryAuthorityRepository;
        public GetLibraryAuthorityDetailRequestHandler(ISchoolManagementRepository<LibraryAuthority> LibraryAuthorityRepository, IMapper mapper)
        {
            _LibraryAuthorityRepository = LibraryAuthorityRepository;
            _mapper = mapper;
        }
        public async Task<LibraryAuthorityDto> Handle(GetLibraryAuthorityDetailRequest request, CancellationToken cancellationToken)
        {
            var LibraryAuthority = await _LibraryAuthorityRepository.Get(request.LibraryAuthorityId);
            return _mapper.Map<LibraryAuthorityDto>(LibraryAuthority);
        }
    }
}
