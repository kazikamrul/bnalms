using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.OnlineChats.Requests.Commands;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.OnlineChats.Handlers.Commands
{
    public class ChangeSeenStatusCommandHandler : IRequestHandler<ChangeSeenStatusCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork; 
        private readonly IMapper _mapper;

        public ChangeSeenStatusCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(ChangeSeenStatusCommand request, CancellationToken cancellationToken)
        {
            var OnlineChats = await _unitOfWork.Repository<OnlineChat>().Get(request.OnlineChatId);
            OnlineChats.ReciverSeenStatus = request.Status;

            if (OnlineChats == null)
                throw new NotFoundException(nameof(OnlineChats), request.OnlineChatId);

            await _unitOfWork.Repository<OnlineChat>().Update(OnlineChats);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
