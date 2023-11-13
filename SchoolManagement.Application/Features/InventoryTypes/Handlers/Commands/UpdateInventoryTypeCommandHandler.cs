using SchoolManagement.Domain;
using AutoMapper;
using MediatR;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Contracts.Persistence;
using System.Threading;
using System.Threading.Tasks;
using SchoolManagement.Application.Features.InventoryTypes.Requests.Commands;
using SchoolManagement.Application.DTOs.InventoryTypes.Validators;

namespace SchoolManagement.Application.Features.InventoryTypes.Handlers.Commands
{
    public class UpdateInventoryTypeCommandHandler : IRequestHandler<UpdateInventoryTypeCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateInventoryTypeCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateInventoryTypeCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateInventoryTypeDtoValidator(); 
             var validationResult = await validator.ValidateAsync(request.InventoryTypeDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var InventoryType = await _unitOfWork.Repository<InventoryType>().Get(request.InventoryTypeDto.InventoryTypeId);

            if (InventoryType is null)
                throw new NotFoundException(nameof(InventoryType), request.InventoryTypeDto.InventoryTypeId);

            _mapper.Map(request.InventoryTypeDto, InventoryType);

            await _unitOfWork.Repository<InventoryType>().Update(InventoryType);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
