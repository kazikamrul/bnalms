using SchoolManagement.Domain;
using AutoMapper;
using MediatR;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Contracts.Persistence;
using System.Threading;
using System.Threading.Tasks;
using SchoolManagement.Application.Features.NoticeInfos.Requests.Commands;
using SchoolManagement.Application.DTOs.NoticeInfo.Validators;
using SchoolManagement.Application.DTOs.NoticeInfo;

namespace SchoolManagement.Application.Features.NoticeInfos.Handlers.Commands
{
    public class UpdateNoticeInfoListByMemberCommandHandler : IRequestHandler<UpdateNoticeInfoListByMemberCommand, Unit>
    {
        private readonly ISchoolManagementRepository<NoticeInfo> _NoticeInfoRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateNoticeInfoListByMemberCommandHandler(ISchoolManagementRepository<NoticeInfo> NoticeInfoRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _NoticeInfoRepository= NoticeInfoRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateNoticeInfoListByMemberCommand request, CancellationToken cancellationToken)
        {
            IQueryable<NoticeInfo> noticeList = _NoticeInfoRepository.FilterWithInclude(x => x.MemberInfoId == request.MemberInfoId && x.ViewStatus == 0);
            var noticeListDtos = _mapper.Map<List<NoticeInfoDto>>(noticeList);

            foreach (var item in noticeListDtos)
            {
                var Notice = await _unitOfWork.Repository<NoticeInfo>().Get(item.NoticeInfoId);
                Notice.ViewStatus = 1;

                await _unitOfWork.Repository<NoticeInfo>().Update(Notice);
                await _unitOfWork.Save();
            }

            return Unit.Value;
        }
    }
}
