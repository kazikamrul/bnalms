using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.Areas.Requests.Commands;
using SchoolManagement.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.Areas.Handlers.Commands
{
    public class DeleteAreaCommandHandler : IRequestHandler<DeleteAreaCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteAreaCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteAreaCommand request, CancellationToken cancellationToken)
        {
            var Area = await _unitOfWork.Repository<Area>().Get(request.AreaId);

            if (Area == null)
                throw new NotFoundException(nameof(Area), request.AreaId);

            await _unitOfWork.Repository<Area>().Delete(Area);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
