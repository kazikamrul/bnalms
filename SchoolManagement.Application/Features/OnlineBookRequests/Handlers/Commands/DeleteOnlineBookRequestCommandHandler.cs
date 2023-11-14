using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.OnlineBookRequests.Requests.Commands;
using SchoolManagement.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.OnlineBookRequests.Handlers.Commands
{
    public class DeleteOnlineBookRequestCommandHandler : IRequestHandler<DeleteOnlineBookRequestCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteOnlineBookRequestCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteOnlineBookRequestCommand request, CancellationToken cancellationToken)
        {
            var OnlineBookRequest = await _unitOfWork.Repository<OnlineBookRequest>().Get(request.OnlineBookRequestId);

            if (OnlineBookRequest == null)
                throw new NotFoundException(nameof(OnlineBookRequest), request.OnlineBookRequestId);

            await _unitOfWork.Repository<OnlineBookRequest>().Delete(OnlineBookRequest);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
