using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.FeeCategory;
using SchoolManagement.Application.Features.FeeCategorys.Requests.Queries;
using SchoolManagement.Domain;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.FeeCategorys.Handlers.Queries
{
    public class GetFeeCategoryDetailRequestHandler : IRequestHandler<GetFeeCategoryDetailRequest, FeeCategoryDto>
    {
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<FeeCategory> _FeeCategoryRepository;
        public GetFeeCategoryDetailRequestHandler(ISchoolManagementRepository<FeeCategory> FeeCategoryRepository, IMapper mapper)
        {
            _FeeCategoryRepository = FeeCategoryRepository;
            _mapper = mapper;
        }
        public async Task<FeeCategoryDto> Handle(GetFeeCategoryDetailRequest request, CancellationToken cancellationToken)
        {
            var FeeCategory = await _FeeCategoryRepository.Get(request.FeeCategoryId);
            return _mapper.Map<FeeCategoryDto>(FeeCategory);
        }
    }
}
