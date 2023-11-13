using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.MainClass;
using SchoolManagement.Application.Features.MainClasses.Requests.Queries;
using SchoolManagement.Domain;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.MainClasses.Handlers.Queries
{
    public class GetMainClassDetailRequestHandler : IRequestHandler<GetMainClassDetailRequest, MainClassDto>
    {
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<MainClass> _MainClassRepository;
        public GetMainClassDetailRequestHandler(ISchoolManagementRepository<MainClass> MainClassRepository, IMapper mapper)
        {
            _MainClassRepository = MainClassRepository;
            _mapper = mapper;
        }
        public async Task<MainClassDto> Handle(GetMainClassDetailRequest request, CancellationToken cancellationToken)
        {
            var MainClass = await _MainClassRepository.Get(request.MainClassId);
            return _mapper.Map<MainClassDto>(MainClass);
        }
    }
}
