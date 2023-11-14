using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.AuthorityCategory;
using SchoolManagement.Application.Features.AuthorityCategorys.Requests.Queries;
using SchoolManagement.Domain;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.AuthorityCategorys.Handlers.Queries
{
    public class GetAuthorityCategoryDetailRequestHandler : IRequestHandler<GetAuthorityCategoryDetailRequest, AuthorityCategoryDto>
    {
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<AuthorityCategory> _AuthorityCategoryRepository;
        public GetAuthorityCategoryDetailRequestHandler(ISchoolManagementRepository<AuthorityCategory> AuthorityCategoryRepository, IMapper mapper)
        {
            _AuthorityCategoryRepository = AuthorityCategoryRepository;
            _mapper = mapper;
        }
        public async Task<AuthorityCategoryDto> Handle(GetAuthorityCategoryDetailRequest request, CancellationToken cancellationToken)
        {
            var AuthorityCategory = await _AuthorityCategoryRepository.Get(request.AuthorityCategoryId);
            return _mapper.Map<AuthorityCategoryDto>(AuthorityCategory);
        }
    }
}
