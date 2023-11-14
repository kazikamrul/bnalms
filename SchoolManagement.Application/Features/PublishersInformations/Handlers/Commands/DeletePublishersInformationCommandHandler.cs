using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.PublishersInformations.Requests.Commands;
using SchoolManagement.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.PublishersInformations.Handlers.Commands
{
    public class DeletePublishersInformationCommandHandler : IRequestHandler<DeletePublishersInformationCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeletePublishersInformationCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeletePublishersInformationCommand request, CancellationToken cancellationToken)
        {
            var PublishersInformation = await _unitOfWork.Repository<PublishersInformation>().Get(request.PublishersInformationId);

            if (PublishersInformation == null)
                throw new NotFoundException(nameof(PublishersInformation), request.PublishersInformationId);

            await _unitOfWork.Repository<PublishersInformation>().Delete(PublishersInformation);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
