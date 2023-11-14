using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.NoticeType;
using SchoolManagement.Application.Features.NoticeTypes.Requests.Queries;
using SchoolManagement.Domain;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.NoticeTypes.Handlers.Queries
{
    public class GetNoticeTypeDetailRequestHandler : IRequestHandler<GetNoticeTypeDetailRequest, NoticeTypeDto>
    {
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<NoticeType> _NoticeTypeRepository;
        public GetNoticeTypeDetailRequestHandler(ISchoolManagementRepository<NoticeType> NoticeTypeRepository, IMapper mapper)
        {
            _NoticeTypeRepository = NoticeTypeRepository;
            _mapper = mapper;
        }
        public async Task<NoticeTypeDto> Handle(GetNoticeTypeDetailRequest request, CancellationToken cancellationToken)
        {
            var NoticeType = await _NoticeTypeRepository.Get(request.NoticeTypeId);
            return _mapper.Map<NoticeTypeDto>(NoticeType);
        }
    }
}
