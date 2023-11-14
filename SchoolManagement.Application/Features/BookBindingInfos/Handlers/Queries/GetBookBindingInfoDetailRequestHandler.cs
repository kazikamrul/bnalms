using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.BookBindingInfo;
using SchoolManagement.Application.Features.BookBindingInfos.Requests.Queries;
using SchoolManagement.Domain;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.BookBindingInfos.Handlers.Queries
{
    public class GetBookBindingInfoDetailRequestHandler : IRequestHandler<GetBookBindingInfoDetailRequest, BookBindingInfoDto>
    {
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<BookBindingInfo> _BookBindingInfoRepository;
        public GetBookBindingInfoDetailRequestHandler(ISchoolManagementRepository<BookBindingInfo> BookBindingInfoRepository, IMapper mapper)
        {
            _BookBindingInfoRepository = BookBindingInfoRepository;
            _mapper = mapper;
        }
        public async Task<BookBindingInfoDto> Handle(GetBookBindingInfoDetailRequest request, CancellationToken cancellationToken)
        {
            //var BookBindingInfo = await _BookBindingInfoRepository.Get(request.BookBindingInfoId);
            //return _mapper.Map<BookBindingInfoDto>(BookBindingInfo);
            var BookBindingInfo = _BookBindingInfoRepository.FinedOneInclude(x => x.BookBindingInfoId == request.BookBindingInfoId, "BookInformation.BookTitleInfo", "BookInformation.BookCategory");
            return _mapper.Map<BookBindingInfoDto>(BookBindingInfo);
        }
    }
}
