using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.Sources.Requests.Commands;
using SchoolManagement.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.Sources.Handlers.Commands
{
    public class DeleteSourceCommandHandler : IRequestHandler<DeleteSourceCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteSourceCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteSourceCommand request, CancellationToken cancellationToken)
        {
            var Source = await _unitOfWork.Repository<Source>().Get(request.SourceId);

            if (Source == null)
                throw new NotFoundException(nameof(Source), request.SourceId);

            await _unitOfWork.Repository<Source>().Delete(Source);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
