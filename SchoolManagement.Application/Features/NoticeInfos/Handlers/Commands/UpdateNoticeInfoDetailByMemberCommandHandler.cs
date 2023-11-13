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
    public class UpdateNoticeInfoDetailByMemberCommandHandler : IRequestHandler<UpdateNoticeInfoDetailByMemberCommand, Unit>
    {
        private readonly ISchoolManagementRepository<NoticeInfo> _NoticeInfoRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateNoticeInfoDetailByMemberCommandHandler(ISchoolManagementRepository<NoticeInfo> NoticeInfoRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _NoticeInfoRepository= NoticeInfoRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateNoticeInfoDetailByMemberCommand request, CancellationToken cancellationToken)
        {
            var Notice = await _unitOfWork.Repository<NoticeInfo>().Get(request.NoticeInfoId);
            Notice.DetailViewStatus = 1;

            await _unitOfWork.Repository<NoticeInfo>().Update(Notice);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
