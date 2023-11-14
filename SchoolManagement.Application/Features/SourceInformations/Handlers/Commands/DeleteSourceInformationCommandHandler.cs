using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.SourceInformations.Requests.Commands;
using SchoolManagement.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.SourceInformations.Handlers.Commands
{
    public class DeleteSourceInformationCommandHandler : IRequestHandler<DeleteSourceInformationCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteSourceInformationCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteSourceInformationCommand request, CancellationToken cancellationToken)
        {
            var SourceInformation = await _unitOfWork.Repository<SourceInformation>().Get(request.SourceInformationId);

            if (SourceInformation == null)
                throw new NotFoundException(nameof(SourceInformation), request.SourceInformationId);

            await _unitOfWork.Repository<SourceInformation>().Delete(SourceInformation);
           
                await _unitOfWork.Save();
           

            return Unit.Value;
        }
    }
}
