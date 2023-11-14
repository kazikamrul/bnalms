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
    public class UpdateRequestAndCancelStatusCommandHandler : IRequestHandler<UpdateRequestAndCancelStatusCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateRequestAndCancelStatusCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateRequestAndCancelStatusCommand request, CancellationToken cancellationToken)
        {
            //var validator = new UpdateOnlineBookRequestDtoValidator(); 
            // var validationResult = await validator.ValidateAsync(request.OnlineBookRequestId);

            //if (validationResult.IsValid == false)
            //    throw new ValidationException(validationResult);

            var OnlineBookRequest = await _unitOfWork.Repository<OnlineBookRequest>().Get(request.OnlineBookRequestId);

            if (OnlineBookRequest is null)
                throw new NotFoundException(nameof(OnlineBookRequest), request.OnlineBookRequestId);

            //_mapper.Map(request.OnlineBookRequestDto, OnlineBookRequest);
            OnlineBookRequest.RequestStatus = 1;
            OnlineBookRequest.CancelStatus = 1;

            await _unitOfWork.Repository<OnlineBookRequest>().Update(OnlineBookRequest);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
