using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.BookInformation;
using SchoolManagement.Application.Features.BookInformations.Requests.Queries;
using SchoolManagement.Domain;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.BookInformations.Handlers.Queries
{
    public class GetBookInformationDetailRequestHandler : IRequestHandler<GetBookInformationDetailRequest, BookInformationDto>
    {
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<BookInformation> _BookInformationRepository;
        public GetBookInformationDetailRequestHandler(ISchoolManagementRepository<BookInformation> BookInformationRepository, IMapper mapper)
        {
            _BookInformationRepository = BookInformationRepository;
            _mapper = mapper;
        }
        public async Task<BookInformationDto> Handle(GetBookInformationDetailRequest request, CancellationToken cancellationToken)
        {
            //var BookInformation = await _BookInformationRepository.Get(request.BookInformationId);
            //return _mapper.Map<BookInformationDto>(BookInformation);
            var BookInformation = _BookInformationRepository.FinedOneInclude(x => x.BookInformationId == request.BookInformationId, "BookCategory", "BookTitleInfo", "MainClass", "RowInfo", "ShelfInfo", "Language", "Source");
            return _mapper.Map<BookInformationDto>(BookInformation);
        }
    }
}
