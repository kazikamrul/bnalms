using SchoolManagement.Domain;
using AutoMapper;
using MediatR;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Contracts.Persistence;
using System.Threading;
using System.Threading.Tasks;
using SchoolManagement.Application.Features.EventInfos.Requests.Commands;
using SchoolManagement.Application.DTOs.EventInfo.Validators;

namespace SchoolManagement.Application.Features.EventInfos.Handlers.Commands
{
    public class UpdateEventInfoCommandHandler : IRequestHandler<UpdateEventInfoCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateEventInfoCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateEventInfoCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateEventInfoDtoValidator(); 
             var validationResult = await validator.ValidateAsync(request.EventInfoDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var EventInfo = await _unitOfWork.Repository<EventInfo>().Get(request.EventInfoDto.EventInfoId);

            if (EventInfo is null)
                throw new NotFoundException(nameof(EventInfo), request.EventInfoDto.EventInfoId);

            _mapper.Map(request.EventInfoDto, EventInfo);

            await _unitOfWork.Repository<EventInfo>().Update(EventInfo);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
