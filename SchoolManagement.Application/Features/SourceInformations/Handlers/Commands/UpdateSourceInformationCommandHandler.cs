using SchoolManagement.Domain;
using AutoMapper;
using MediatR;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Contracts.Persistence;
using System.Threading;
using System.Threading.Tasks;
using SchoolManagement.Application.Features.SourceInformations.Requests.Commands;
using SchoolManagement.Application.DTOs.SourceInformation.Validators;

namespace SchoolManagement.Application.Features.SourceInformations.Handlers.Commands
{
    public class UpdateSourceInformationCommandHandler : IRequestHandler<UpdateSourceInformationCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateSourceInformationCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateSourceInformationCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateSourceInformationDtoValidator(); 
             var validationResult = await validator.ValidateAsync(request.SourceInformationDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var SourceInformation = await _unitOfWork.Repository<SourceInformation>().Get(request.SourceInformationDto.SourceInformationId);

            if (SourceInformation is null)
                throw new NotFoundException(nameof(SourceInformation), request.SourceInformationDto.SourceInformationId);

            _mapper.Map(request.SourceInformationDto, SourceInformation);

            await _unitOfWork.Repository<SourceInformation>().Update(SourceInformation);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
