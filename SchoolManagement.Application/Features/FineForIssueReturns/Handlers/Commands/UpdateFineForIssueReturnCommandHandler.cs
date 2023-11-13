using SchoolManagement.Domain;
using AutoMapper;
using MediatR;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Contracts.Persistence;
using System.Threading;
using System.Threading.Tasks;
using SchoolManagement.Application.Features.FineForIssueReturns.Requests.Commands;
using SchoolManagement.Application.DTOs.FineForIssueReturns.Validators;

namespace SchoolManagement.Application.Features.FineForIssueReturns.Handlers.Commands
{
    public class UpdateFineForIssueReturnCommandHandler : IRequestHandler<UpdateFineForIssueReturnCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateFineForIssueReturnCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateFineForIssueReturnCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateFineForIssueReturnDtoValidator(); 
             var validationResult = await validator.ValidateAsync(request.FineForIssueReturnDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var FineForIssueReturn = await _unitOfWork.Repository<FineForIssueReturn>().Get(request.FineForIssueReturnDto.FineForIssueReturnId);

            if (FineForIssueReturn is null)
                throw new NotFoundException(nameof(FineForIssueReturn), request.FineForIssueReturnDto.FineForIssueReturnId);

            _mapper.Map(request.FineForIssueReturnDto, FineForIssueReturn);

            await _unitOfWork.Repository<FineForIssueReturn>().Update(FineForIssueReturn);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
