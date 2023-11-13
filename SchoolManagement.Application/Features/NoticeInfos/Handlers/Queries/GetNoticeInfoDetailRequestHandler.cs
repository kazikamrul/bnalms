using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.NoticeInfo;
using SchoolManagement.Application.Features.NoticeInfos.Requests.Queries;
using SchoolManagement.Domain;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.NoticeInfos.Handlers.Queries
{
    public class GetNoticeInfoDetailRequestHandler : IRequestHandler<GetNoticeInfoDetailRequest, NoticeInfoDto>
    {
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<NoticeInfo> _NoticeInfoRepository;
        public GetNoticeInfoDetailRequestHandler(ISchoolManagementRepository<NoticeInfo> NoticeInfoRepository, IMapper mapper)
        {
            _NoticeInfoRepository = NoticeInfoRepository;
            _mapper = mapper;
        }
        public async Task<NoticeInfoDto> Handle(GetNoticeInfoDetailRequest request, CancellationToken cancellationToken)
        {
            var NoticeInfo = await _NoticeInfoRepository.Get(request.NoticeInfoId);
            return _mapper.Map<NoticeInfoDto>(NoticeInfo);
        }
    }
}
