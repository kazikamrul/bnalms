using SchoolManagement.Domain;
using AutoMapper;
using MediatR;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Contracts.Persistence;
using System.Threading;
using System.Threading.Tasks;
using SchoolManagement.Application.Features.SecurityQuestions.Requests.Commands;
using SchoolManagement.Application.DTOs.SecurityQuestion.Validators;

namespace SchoolManagement.Application.Features.SecurityQuestions.Handlers.Commands
{
    public class UpdateSecurityQuestionCommandHandler : IRequestHandler<UpdateSecurityQuestionCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateSecurityQuestionCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateSecurityQuestionCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateSecurityQuestionDtoValidator(); 
             var validationResult = await validator.ValidateAsync(request.SecurityQuestionDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var SecurityQuestion = await _unitOfWork.Repository<SecurityQuestion>().Get(request.SecurityQuestionDto.SecurityQuestionId);

            if (SecurityQuestion is null)
                throw new NotFoundException(nameof(SecurityQuestion), request.SecurityQuestionDto.SecurityQuestionId);

            _mapper.Map(request.SecurityQuestionDto, SecurityQuestion);

            await _unitOfWork.Repository<SecurityQuestion>().Update(SecurityQuestion);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
