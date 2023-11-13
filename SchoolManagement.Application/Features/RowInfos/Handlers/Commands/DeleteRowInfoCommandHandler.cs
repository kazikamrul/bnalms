using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.RowInfos.Requests.Commands;
using SchoolManagement.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.RowInfos.Handlers.Commands
{
    public class DeleteRowInfoCommandHandler : IRequestHandler<DeleteRowInfoCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteRowInfoCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteRowInfoCommand request, CancellationToken cancellationToken)
        {
            var RowInfo = await _unitOfWork.Repository<RowInfo>().Get(request.RowInfoId);

            if (RowInfo == null)
                throw new NotFoundException(nameof(RowInfo), request.RowInfoId);

            await _unitOfWork.Repository<RowInfo>().Delete(RowInfo);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
