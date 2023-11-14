using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.FineForIssueReturns.Validators;
using SchoolManagement.Application.Features.FineForIssueReturns.Requests.Commands;
using SchoolManagement.Application.Responses;
using SchoolManagement.Domain;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.FineForIssueReturns.Handlers.Commands
{
    public class CreateFineForIssueReturnCommandHandler : IRequestHandler<CreateFineForIssueReturnCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateFineForIssueReturnCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateFineForIssueReturnCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateFineForIssueReturnDtoValidator();
            var validationResult = await validator.ValidateAsync(request.FineForIssueReturnDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            { 
                var FineForIssueReturn = _mapper.Map<FineForIssueReturn>(request.FineForIssueReturnDto);

                FineForIssueReturn = await _unitOfWork.Repository<FineForIssueReturn>().Add(FineForIssueReturn);

                //var bookIssueAndSubmission = await _unitOfWork.Repository<BookIssueAndSubmission>().Get(FineForIssueReturn.BookIssueAndSubmissionId.Value);
                //bookIssueAndSubmission.IssueReturnFineAmount = request.FineForIssueReturnDto.Amount;
                //await _unitOfWork.Repository<BookIssueAndSubmission>().Update(bookIssueAndSubmission);

                await _unitOfWork.Save();


                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = FineForIssueReturn.FineForIssueReturnId;
            }

            return response;
        }
    }
}
