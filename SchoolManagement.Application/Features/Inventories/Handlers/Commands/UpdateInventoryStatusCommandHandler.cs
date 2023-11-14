using SchoolManagement.Domain;
using AutoMapper;
using MediatR;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Contracts.Persistence;
using System.Threading;
using System.Threading.Tasks;
using SchoolManagement.Application.Features.Inventorys.Requests.Commands;
using SchoolManagement.Application.DTOs.Inventorys.Validators;

namespace SchoolManagement.Application.Features.Inventorys.Handlers.Commands
{
    public class UpdateInventoryStatusCommandHandler : IRequestHandler<UpdateInventoryStatusCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateInventoryStatusCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateInventoryStatusCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateInventoryDtoValidator(); 
             var validationResult = await validator.ValidateAsync(request.InventoryDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var Inventory = await _unitOfWork.Repository<Inventory>().Get(request.InventoryDto.InventoryId);

            if (Inventory is null)
                throw new NotFoundException(nameof(Inventory), request.InventoryDto.InventoryId);

            // _mapper.Map(request.InventoryDto, Inventory);
            Inventory.DamageDate = request.InventoryDto.DamageDate;
            Inventory.DamageStatus = request.InventoryDto.DamageStatus;
            Inventory.DamageReason = request.InventoryDto.DamageReason;

            await _unitOfWork.Repository<Inventory>().Update(Inventory);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
