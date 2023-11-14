using SchoolManagement.Domain;
using AutoMapper;
using MediatR;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Contracts.Persistence;
using System.Threading;
using System.Threading.Tasks;
using SchoolManagement.Application.Features.ShelfInfos.Requests.Commands;
using SchoolManagement.Application.DTOs.ShelfInfo.Validators;

namespace SchoolManagement.Application.Features.ShelfInfos.Handlers.Commands
{
    public class UpdateShelfInfoCommandHandler : IRequestHandler<UpdateShelfInfoCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateShelfInfoCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateShelfInfoCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateShelfInfoDtoValidator(); 
             var validationResult = await validator.ValidateAsync(request.ShelfInfoDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var ShelfInfo = await _unitOfWork.Repository<ShelfInfo>().Get(request.ShelfInfoDto.ShelfInfoId);

            if (ShelfInfo is null)
                throw new NotFoundException(nameof(ShelfInfo), request.ShelfInfoDto.ShelfInfoId);

            _mapper.Map(request.ShelfInfoDto, ShelfInfo);

            await _unitOfWork.Repository<ShelfInfo>().Update(ShelfInfo);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
