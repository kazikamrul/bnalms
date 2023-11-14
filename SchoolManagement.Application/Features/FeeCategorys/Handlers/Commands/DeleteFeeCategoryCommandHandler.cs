using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.FeeCategorys.Requests.Commands;
using SchoolManagement.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.FeeCategorys.Handlers.Commands
{
    public class DeleteFeeCategoryCommandHandler : IRequestHandler<DeleteFeeCategoryCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteFeeCategoryCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteFeeCategoryCommand request, CancellationToken cancellationToken)
        {
            var FeeCategory = await _unitOfWork.Repository<FeeCategory>().Get(request.FeeCategoryId);

            if (FeeCategory == null)
                throw new NotFoundException(nameof(FeeCategory), request.FeeCategoryId);

            await _unitOfWork.Repository<FeeCategory>().Delete(FeeCategory);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
