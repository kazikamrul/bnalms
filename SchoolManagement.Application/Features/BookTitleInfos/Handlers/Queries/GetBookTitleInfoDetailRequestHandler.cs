using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.BookTitleInfo;
using SchoolManagement.Application.Features.BookTitleInfos.Requests.Queries;
using SchoolManagement.Domain;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.BookTitleInfos.Handlers.Queries
{
    public class GetBookTitleInfoDetailRequestHandler : IRequestHandler<GetBookTitleInfoDetailRequest, BookTitleInfoDto>
    {
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<BookTitleInfo> _BookTitleInfoRepository;
        public GetBookTitleInfoDetailRequestHandler(ISchoolManagementRepository<BookTitleInfo> BookTitleInfoRepository, IMapper mapper)
        {
            _BookTitleInfoRepository = BookTitleInfoRepository;
            _mapper = mapper;
        }
        public async Task<BookTitleInfoDto> Handle(GetBookTitleInfoDetailRequest request, CancellationToken cancellationToken)
        {
            var BookTitleInfo = await _BookTitleInfoRepository.Get(request.BookTitleInfoId);
            return _mapper.Map<BookTitleInfoDto>(BookTitleInfo);
        }
    }
}
