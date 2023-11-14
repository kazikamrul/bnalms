using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.MainClasses.Requests.Commands;
using SchoolManagement.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.MainClasses.Handlers.Commands
{
    public class DeleteMainClassCommandHandler : IRequestHandler<DeleteMainClassCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteMainClassCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteMainClassCommand request, CancellationToken cancellationToken)
        {
            var MainClass = await _unitOfWork.Repository<MainClass>().Get(request.MainClassId);

            if (MainClass == null)
                throw new NotFoundException(nameof(MainClass), request.MainClassId);

            await _unitOfWork.Repository<MainClass>().Delete(MainClass);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
