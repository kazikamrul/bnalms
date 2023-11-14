using SchoolManagement.Domain;
using AutoMapper;
using MediatR;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Contracts.Persistence;
using System.Threading;
using System.Threading.Tasks;
using SchoolManagement.Application.Features.PublishersInformations.Requests.Commands;
using SchoolManagement.Application.DTOs.PublishersInformation.Validators;

namespace SchoolManagement.Application.Features.PublishersInformations.Handlers.Commands
{
    public class UpdatePublishersInformationCommandHandler : IRequestHandler<UpdatePublishersInformationCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdatePublishersInformationCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdatePublishersInformationCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdatePublishersInformationDtoValidator(); 
             var validationResult = await validator.ValidateAsync(request.PublishersInformationDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var PublishersInformation = await _unitOfWork.Repository<PublishersInformation>().Get(request.PublishersInformationDto.PublishersInformationId);

            if (PublishersInformation is null)
                throw new NotFoundException(nameof(PublishersInformation), request.PublishersInformationDto.PublishersInformationId);

            _mapper.Map(request.PublishersInformationDto, PublishersInformation);

            await _unitOfWork.Repository<PublishersInformation>().Update(PublishersInformation);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
