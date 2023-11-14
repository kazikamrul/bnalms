using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.AuthorInformation;
using SchoolManagement.Application.Features.AuthorInformations.Requests.Queries;
using SchoolManagement.Domain;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.AuthorInformations.Handlers.Queries
{
    public class GetAuthorInformationDetailRequestHandler : IRequestHandler<GetAuthorInformationDetailRequest, AuthorInformationDto>
    {
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<AuthorInformation> _AuthorInformationRepository;
        public GetAuthorInformationDetailRequestHandler(ISchoolManagementRepository<AuthorInformation> AuthorInformationRepository, IMapper mapper)
        {
            _AuthorInformationRepository = AuthorInformationRepository;
            _mapper = mapper;
        }
        public async Task<AuthorInformationDto> Handle(GetAuthorInformationDetailRequest request, CancellationToken cancellationToken)
        {
            var AuthorInformation = await _AuthorInformationRepository.Get(request.AuthorInformationId);
            return _mapper.Map<AuthorInformationDto>(AuthorInformation);
        }
    }
}
