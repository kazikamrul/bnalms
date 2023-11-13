using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.ShelfInfos.Requests.Commands;
using SchoolManagement.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.ShelfInfos.Handlers.Commands
{
    public class DeleteShelfInfoCommandHandler : IRequestHandler<DeleteShelfInfoCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteShelfInfoCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteShelfInfoCommand request, CancellationToken cancellationToken)
        {
            var ShelfInfo = await _unitOfWork.Repository<ShelfInfo>().Get(request.ShelfInfoId);

            if (ShelfInfo == null)
                throw new NotFoundException(nameof(ShelfInfo), request.ShelfInfoId);

            await _unitOfWork.Repository<ShelfInfo>().Delete(ShelfInfo);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
