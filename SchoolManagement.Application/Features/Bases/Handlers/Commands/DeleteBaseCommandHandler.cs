using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.Bases.Requests.Commands;
using SchoolManagement.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.Bases.Handlers.Commands
{
    public class DeleteBaseCommandHandler : IRequestHandler<DeleteBaseCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteBaseCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteBaseCommand request, CancellationToken cancellationToken)
        {
            var Base = await _unitOfWork.Repository<Base>().Get(request.BaseId);

            if (Base == null)
                throw new NotFoundException(nameof(Base), request.BaseId);

            await _unitOfWork.Repository<Base>().Delete(Base);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
