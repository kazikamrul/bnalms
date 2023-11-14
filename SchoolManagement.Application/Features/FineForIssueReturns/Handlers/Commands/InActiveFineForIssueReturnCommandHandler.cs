using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.FineForIssueReturns.Requests.Commands;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.FineForIssueReturns.Handlers.Commands
{
    public class InActiveFineForIssueReturnCommandHandler : IRequestHandler<InActiveFineForIssueReturnCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public InActiveFineForIssueReturnCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(InActiveFineForIssueReturnCommand request, CancellationToken cancellationToken)
        {
            var FineForIssueReturn = await _unitOfWork.Repository<FineForIssueReturn>().Get(request.FineForIssueReturnId);
            FineForIssueReturn.IsActive = false;

            if (FineForIssueReturn == null)
                throw new NotFoundException(nameof(FineForIssueReturn), request.FineForIssueReturnId);

            await _unitOfWork.Repository<FineForIssueReturn>().Update(FineForIssueReturn);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
