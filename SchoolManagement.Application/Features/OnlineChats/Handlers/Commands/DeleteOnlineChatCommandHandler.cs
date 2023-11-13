using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.OnlineChats.Requests.Commands;
using SchoolManagement.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.OnlineChats.Handlers.Commands
{
    public class DeleteOnlineChatCommandHandler : IRequestHandler<DeleteOnlineChatCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteOnlineChatCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteOnlineChatCommand request, CancellationToken cancellationToken)
        {
            var OnlineChat = await _unitOfWork.Repository<OnlineChat>().Get(request.OnlineChatId);

            if (OnlineChat == null)
                throw new NotFoundException(nameof(OnlineChat), request.OnlineChatId);

            await _unitOfWork.Repository<OnlineChat>().Delete(OnlineChat);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
