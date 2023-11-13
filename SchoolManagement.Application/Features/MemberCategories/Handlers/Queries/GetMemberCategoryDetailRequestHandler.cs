using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.MemberCategory;
using SchoolManagement.Application.Features.MemberCategorys.Requests.Queries;
using SchoolManagement.Domain;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.MemberCategorys.Handlers.Queries
{
    public class GetMemberCategoryDetailRequestHandler : IRequestHandler<GetMemberCategoryDetailRequest, MemberCategoryDto>
    {
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<MemberCategory> _MemberCategoryRepository;
        public GetMemberCategoryDetailRequestHandler(ISchoolManagementRepository<MemberCategory> MemberCategoryRepository, IMapper mapper)
        {
            _MemberCategoryRepository = MemberCategoryRepository;
            _mapper = mapper;
        }
        public async Task<MemberCategoryDto> Handle(GetMemberCategoryDetailRequest request, CancellationToken cancellationToken)
        {
            var MemberCategory = await _MemberCategoryRepository.Get(request.MemberCategoryId);
            return _mapper.Map<MemberCategoryDto>(MemberCategory);
        }
    }
}
