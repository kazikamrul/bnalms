using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.FeeInformations.Requests.Commands;
using SchoolManagement.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.FeeInformations.Handlers.Commands
{
    public class DeleteFeeInformationCommandHandler : IRequestHandler<DeleteFeeInformationCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteFeeInformationCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteFeeInformationCommand request, CancellationToken cancellationToken)
        {
            var FeeInformation = await _unitOfWork.Repository<FeeInformation>().Get(request.FeeInformationId);

            if (FeeInformation == null)
                throw new NotFoundException(nameof(FeeInformation), request.FeeInformationId);

            await _unitOfWork.Repository<FeeInformation>().Delete(FeeInformation);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
