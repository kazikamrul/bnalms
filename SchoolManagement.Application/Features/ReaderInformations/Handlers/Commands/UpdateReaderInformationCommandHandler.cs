using SchoolManagement.Domain;
using AutoMapper;
using MediatR;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Contracts.Persistence;
using System.Threading;
using System.Threading.Tasks;
using SchoolManagement.Application.Features.ReaderInformations.Requests.Commands;
using SchoolManagement.Application.DTOs.ReaderInformation.Validators;

namespace SchoolManagement.Application.Features.ReaderInformations.Handlers.Commands
{
    public class UpdateReaderInformationCommandHandler : IRequestHandler<UpdateReaderInformationCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateReaderInformationCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateReaderInformationCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateReaderInformationDtoValidator(); 
             var validationResult = await validator.ValidateAsync(request.ReaderInformationDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var ReaderInformation = await _unitOfWork.Repository<ReaderInformation>().Get(request.ReaderInformationDto.ReaderInformationId);

            if (ReaderInformation is null)
                throw new NotFoundException(nameof(ReaderInformation), request.ReaderInformationDto.ReaderInformationId);

            _mapper.Map(request.ReaderInformationDto, ReaderInformation);

            await _unitOfWork.Repository<ReaderInformation>().Update(ReaderInformation);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
