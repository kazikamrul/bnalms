using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.FineForIssueReturns.Requests.Commands;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.FineForIssueReturns.Handlers.Commands
{
    public class ActiveFineForIssueReturnCommandHandler : IRequestHandler<ActiveFineForIssueReturnCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ActiveFineForIssueReturnCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(ActiveFineForIssueReturnCommand request, CancellationToken cancellationToken)
        {
            var FineForIssueReturn = await _unitOfWork.Repository<FineForIssueReturn>().Get(request.FineForIssueReturnId);
            FineForIssueReturn.IsActive = true;

            if (FineForIssueReturn == null)
                throw new NotFoundException(nameof(FineForIssueReturn), request.FineForIssueReturnId);

            await _unitOfWork.Repository<FineForIssueReturn>().Update(FineForIssueReturn);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
