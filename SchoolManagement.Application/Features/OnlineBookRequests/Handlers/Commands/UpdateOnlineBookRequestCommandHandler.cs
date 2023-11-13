using SchoolManagement.Domain;
using AutoMapper;
using MediatR;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Contracts.Persistence;
using System.Threading;
using System.Threading.Tasks;
using SchoolManagement.Application.Features.OnlineBookRequests.Requests.Commands;
using SchoolManagement.Application.DTOs.OnlineBookRequest.Validators;

namespace SchoolManagement.Application.Features.OnlineBookRequests.Handlers.Commands
{
    public class UpdateOnlineBookRequestCommandHandler : IRequestHandler<UpdateOnlineBookRequestCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateOnlineBookRequestCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateOnlineBookRequestCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateOnlineBookRequestDtoValidator(); 
             var validationResult = await validator.ValidateAsync(request.OnlineBookRequestDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var OnlineBookRequest = await _unitOfWork.Repository<OnlineBookRequest>().Get(request.OnlineBookRequestDto.OnlineBookRequestId);

            if (OnlineBookRequest is null)
                throw new NotFoundException(nameof(OnlineBookRequest), request.OnlineBookRequestDto.OnlineBookRequestId);

            _mapper.Map(request.OnlineBookRequestDto, OnlineBookRequest);

            await _unitOfWork.Repository<OnlineBookRequest>().Update(OnlineBookRequest);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
