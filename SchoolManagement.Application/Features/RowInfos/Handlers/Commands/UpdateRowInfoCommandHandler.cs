using SchoolManagement.Domain;
using AutoMapper;
using MediatR;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Contracts.Persistence;
using System.Threading;
using System.Threading.Tasks;
using SchoolManagement.Application.Features.RowInfos.Requests.Commands;
using SchoolManagement.Application.DTOs.RowInfo.Validators;

namespace SchoolManagement.Application.Features.RowInfos.Handlers.Commands
{
    public class UpdateRowInfoCommandHandler : IRequestHandler<UpdateRowInfoCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateRowInfoCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateRowInfoCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateRowInfoDtoValidator(); 
             var validationResult = await validator.ValidateAsync(request.RowInfoDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var RowInfo = await _unitOfWork.Repository<RowInfo>().Get(request.RowInfoDto.RowInfoId);

            if (RowInfo is null)
                throw new NotFoundException(nameof(RowInfo), request.RowInfoDto.RowInfoId);

            _mapper.Map(request.RowInfoDto, RowInfo);

            await _unitOfWork.Repository<RowInfo>().Update(RowInfo);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
