using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.InventoryTypes.Requests.Commands;
using SchoolManagement.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.InventoryTypes.Handlers.Commands
{
    public class DeleteInventoryTypeCommandHandler : IRequestHandler<DeleteInventoryTypeCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteInventoryTypeCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteInventoryTypeCommand request, CancellationToken cancellationToken)
        {
            var InventoryType = await _unitOfWork.Repository<InventoryType>().Get(request.InventoryTypeId);

            if (InventoryType == null)
                throw new NotFoundException(nameof(InventoryType), request.InventoryTypeId);

            await _unitOfWork.Repository<InventoryType>().Delete(InventoryType);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
