using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.DemandBook;
using SchoolManagement.Application.Features.DemandBooks.Requests.Queries;
using SchoolManagement.Domain;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.DemandBooks.Handlers.Queries
{
    public class GetDemandBookDetailRequestHandler : IRequestHandler<GetDemandBookDetailRequest, DemandBookDto>
    {
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<DemandBook> _DemandBookRepository;
        public GetDemandBookDetailRequestHandler(ISchoolManagementRepository<DemandBook> DemandBookRepository, IMapper mapper)
        {
            _DemandBookRepository = DemandBookRepository;
            _mapper = mapper;
        }
        public async Task<DemandBookDto> Handle(GetDemandBookDetailRequest request, CancellationToken cancellationToken)
        {
            var DemandBook = await _DemandBookRepository.Get(request.DemandBookId);
            return _mapper.Map<DemandBookDto>(DemandBook);
        }
    }
}
