using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.EventInfos.Requests.Commands;
using SchoolManagement.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.EventInfos.Handlers.Commands
{
    public class DeleteEventInfoCommandHandler : IRequestHandler<DeleteEventInfoCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteEventInfoCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteEventInfoCommand request, CancellationToken cancellationToken)
        {
            var EventInfo = await _unitOfWork.Repository<EventInfo>().Get(request.EventInfoId);

            if (EventInfo == null)
                throw new NotFoundException(nameof(EventInfo), request.EventInfoId);

            await _unitOfWork.Repository<EventInfo>().Delete(EventInfo);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
