using SchoolManagement.Domain;
using AutoMapper;
using MediatR;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Contracts.Persistence;
using System.Threading;
using System.Threading.Tasks;
using SchoolManagement.Application.Features.SupplierInformations.Requests.Commands;
using SchoolManagement.Application.DTOs.SupplierInformation.Validators;

namespace SchoolManagement.Application.Features.SupplierInformations.Handlers.Commands
{
    public class UpdateSupplierInformationCommandHandler : IRequestHandler<UpdateSupplierInformationCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateSupplierInformationCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateSupplierInformationCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateSupplierInformationDtoValidator(); 
             var validationResult = await validator.ValidateAsync(request.SupplierInformationDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var SupplierInformation = await _unitOfWork.Repository<SupplierInformation>().Get(request.SupplierInformationDto.SupplierInformationId);

            if (SupplierInformation is null)
                throw new NotFoundException(nameof(SupplierInformation), request.SupplierInformationDto.SupplierInformationId);

            _mapper.Map(request.SupplierInformationDto, SupplierInformation);

            await _unitOfWork.Repository<SupplierInformation>().Update(SupplierInformation);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
