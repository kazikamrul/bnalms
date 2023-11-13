using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.HelpLines.Requests.Commands;
using SchoolManagement.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.HelpLines.Handlers.Commands
{
    public class DeleteHelpLineCommandHandler : IRequestHandler<DeleteHelpLineCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteHelpLineCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteHelpLineCommand request, CancellationToken cancellationToken)
        {
            var HelpLine = await _unitOfWork.Repository<HelpLine>().Get(request.HelpLineId);

            if (HelpLine == null)
                throw new NotFoundException(nameof(HelpLine), request.HelpLineId);

            await _unitOfWork.Repository<HelpLine>().Delete(HelpLine);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
