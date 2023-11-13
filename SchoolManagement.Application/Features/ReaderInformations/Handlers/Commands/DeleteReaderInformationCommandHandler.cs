using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.ReaderInformations.Requests.Commands;
using SchoolManagement.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.ReaderInformations.Handlers.Commands
{
    public class DeleteReaderInformationCommandHandler : IRequestHandler<DeleteReaderInformationCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteReaderInformationCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteReaderInformationCommand request, CancellationToken cancellationToken)
        {
            var ReaderInformation = await _unitOfWork.Repository<ReaderInformation>().Get(request.ReaderInformationId);

            if (ReaderInformation == null)
                throw new NotFoundException(nameof(ReaderInformation), request.ReaderInformationId);

            await _unitOfWork.Repository<ReaderInformation>().Delete(ReaderInformation);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
