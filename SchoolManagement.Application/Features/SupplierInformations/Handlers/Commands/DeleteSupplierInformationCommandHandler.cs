using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.SupplierInformations.Requests.Commands;
using SchoolManagement.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.SupplierInformations.Handlers.Commands
{
    public class DeleteSupplierInformationCommandHandler : IRequestHandler<DeleteSupplierInformationCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteSupplierInformationCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteSupplierInformationCommand request, CancellationToken cancellationToken)
        {
            var SupplierInformation = await _unitOfWork.Repository<SupplierInformation>().Get(request.SupplierInformationId);

            if (SupplierInformation == null)
                throw new NotFoundException(nameof(SupplierInformation), request.SupplierInformationId);

            await _unitOfWork.Repository<SupplierInformation>().Delete(SupplierInformation);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
