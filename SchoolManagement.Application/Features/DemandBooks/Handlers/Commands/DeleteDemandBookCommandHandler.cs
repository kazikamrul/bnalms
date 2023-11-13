using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.DemandBooks.Requests.Commands;
using SchoolManagement.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.DemandBooks.Handlers.Commands
{
    public class DeleteDemandBookCommandHandler : IRequestHandler<DeleteDemandBookCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteDemandBookCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteDemandBookCommand request, CancellationToken cancellationToken)
        {
            var DemandBook = await _unitOfWork.Repository<DemandBook>().Get(request.DemandBookId);

            if (DemandBook == null)
                throw new NotFoundException(nameof(DemandBook), request.DemandBookId);

            await _unitOfWork.Repository<DemandBook>().Delete(DemandBook);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
