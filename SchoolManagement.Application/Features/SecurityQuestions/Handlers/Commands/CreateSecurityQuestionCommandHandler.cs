using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.SecurityQuestion.Validators;
using SchoolManagement.Application.Features.SecurityQuestions.Requests.Commands;
using SchoolManagement.Application.Responses;
using SchoolManagement.Domain;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.SecurityQuestions.Handlers.Commands
{
    public class CreateSecurityQuestionCommandHandler : IRequestHandler<CreateSecurityQuestionCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateSecurityQuestionCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateSecurityQuestionCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateSecurityQuestionDtoValidator();
            var validationResult = await validator.ValidateAsync(request.SecurityQuestionDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var SecurityQuestion = _mapper.Map<SecurityQuestion>(request.SecurityQuestionDto);

                SecurityQuestion = await _unitOfWork.Repository<SecurityQuestion>().Add(SecurityQuestion);
                await _unitOfWork.Save();


                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = SecurityQuestion.SecurityQuestionId;
            }

            return response;
        }
    }
}
