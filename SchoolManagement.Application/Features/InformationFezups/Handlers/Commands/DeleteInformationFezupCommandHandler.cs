using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.InformationFezups.Requests.Commands;
using SchoolManagement.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.InformationFezups.Handlers.Commands
{
    public class DeleteInformationFezupCommandHandler : IRequestHandler<DeleteInformationFezupCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteInformationFezupCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteInformationFezupCommand request, CancellationToken cancellationToken)
        {
            var InformationFezup = await _unitOfWork.Repository<InformationFezup>().Get(request.InformationFezupId);

            if (InformationFezup == null)
                throw new NotFoundException(nameof(InformationFezup), request.InformationFezupId);

            await _unitOfWork.Repository<InformationFezup>().Delete(InformationFezup);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
