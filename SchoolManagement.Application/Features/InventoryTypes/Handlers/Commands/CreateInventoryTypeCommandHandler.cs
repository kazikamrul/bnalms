using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.InventoryTypes.Validators;
using SchoolManagement.Application.Features.InventoryTypes.Requests.Commands;
using SchoolManagement.Application.Responses;
using SchoolManagement.Domain;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.InventoryTypes.Handlers.Commands
{
    public class CreateInventoryTypeCommandHandler : IRequestHandler<CreateInventoryTypeCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateInventoryTypeCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateInventoryTypeCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateInventoryTypeDtoValidator();
            var validationResult = await validator.ValidateAsync(request.InventoryTypeDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var InventoryType = _mapper.Map<InventoryType>(request.InventoryTypeDto);

                InventoryType = await _unitOfWork.Repository<InventoryType>().Add(InventoryType);
                await _unitOfWork.Save();


                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = InventoryType.InventoryTypeId;
            }

            return response;
        }
    }
}
