using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.FineForIssueReturns.Requests.Commands;
using SchoolManagement.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.FineForIssueReturns.Handlers.Commands
{
    public class DeleteFineForIssueReturnCommandHandler : IRequestHandler<DeleteFineForIssueReturnCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteFineForIssueReturnCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteFineForIssueReturnCommand request, CancellationToken cancellationToken)
        {
            var FineForIssueReturn = await _unitOfWork.Repository<FineForIssueReturn>().Get(request.FineForIssueReturnId);

            if (FineForIssueReturn == null)
                throw new NotFoundException(nameof(FineForIssueReturn), request.FineForIssueReturnId);

            await _unitOfWork.Repository<FineForIssueReturn>().Delete(FineForIssueReturn);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
