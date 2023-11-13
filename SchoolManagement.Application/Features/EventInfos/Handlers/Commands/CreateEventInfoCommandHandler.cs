using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.EventInfo.Validators;
using SchoolManagement.Application.Features.EventInfos.Requests.Commands;
using SchoolManagement.Application.Responses;
using SchoolManagement.Domain;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.EventInfos.Handlers.Commands
{
    public class CreateEventInfoCommandHandler : IRequestHandler<CreateEventInfoCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateEventInfoCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateEventInfoCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateEventInfoDtoValidator();
            var validationResult = await validator.ValidateAsync(request.EventInfoDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var EventInfo = _mapper.Map<EventInfo>(request.EventInfoDto);

                EventInfo = await _unitOfWork.Repository<EventInfo>().Add(EventInfo);
                EventInfo.EventFrom = EventInfo.EventFrom.Value.AddDays(1.0);
                EventInfo.EventTo = EventInfo.EventTo.Value.AddDays(1.0);
                await _unitOfWork.Save();


                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = EventInfo.EventInfoId;
            }

            return response;
        }
    }
}
