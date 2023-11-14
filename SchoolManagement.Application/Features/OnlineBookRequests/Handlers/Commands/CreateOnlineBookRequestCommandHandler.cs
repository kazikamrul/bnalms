using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.OnlineBookRequest.Validators;
using SchoolManagement.Application.Features.OnlineBookRequests.Requests.Commands;
using SchoolManagement.Application.Responses;
using SchoolManagement.Domain;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.OnlineBookRequests.Handlers.Commands
{
    public class CreateOnlineBookRequestCommandHandler : IRequestHandler<CreateOnlineBookRequestCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateOnlineBookRequestCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateOnlineBookRequestCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateOnlineBookRequestDtoValidator();
            var validationResult = await validator.ValidateAsync(request.OnlineBookRequestDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var OnlineBookRequest = _mapper.Map<OnlineBookRequest>(request.OnlineBookRequestDto);

                OnlineBookRequest = await _unitOfWork.Repository<OnlineBookRequest>().Add(OnlineBookRequest);                
                await _unitOfWork.Save();


                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = OnlineBookRequest.OnlineBookRequestId;
            }

            return response;
        }
    }
}
