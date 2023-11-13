using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.NoticeInfos.Requests.Commands;
using SchoolManagement.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.NoticeInfos.Handlers.Commands
{
    public class DeleteNoticeInfoCommandHandler : IRequestHandler<DeleteNoticeInfoCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteNoticeInfoCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteNoticeInfoCommand request, CancellationToken cancellationToken)
        {
            var NoticeInfo = await _unitOfWork.Repository<NoticeInfo>().Get(request.NoticeInfoId);

            if (NoticeInfo == null)
                throw new NotFoundException(nameof(NoticeInfo), request.NoticeInfoId);

            await _unitOfWork.Repository<NoticeInfo>().Delete(NoticeInfo);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
