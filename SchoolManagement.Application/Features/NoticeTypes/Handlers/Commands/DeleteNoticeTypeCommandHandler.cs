using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.NoticeTypes.Requests.Commands;
using SchoolManagement.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.NoticeTypes.Handlers.Commands
{
    public class DeleteNoticeTypeCommandHandler : IRequestHandler<DeleteNoticeTypeCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteNoticeTypeCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteNoticeTypeCommand request, CancellationToken cancellationToken)
        {
            var NoticeType = await _unitOfWork.Repository<NoticeType>().Get(request.NoticeTypeId);

            if (NoticeType == null)
                throw new NotFoundException(nameof(NoticeType), request.NoticeTypeId);

            await _unitOfWork.Repository<NoticeType>().Delete(NoticeType);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
