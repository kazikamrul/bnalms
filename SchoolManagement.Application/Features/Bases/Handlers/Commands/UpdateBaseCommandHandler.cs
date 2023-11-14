using SchoolManagement.Domain;
using AutoMapper;
using MediatR;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Contracts.Persistence;
using System.Threading;
using System.Threading.Tasks;
using SchoolManagement.Application.Features.Bases.Requests.Commands;
using SchoolManagement.Application.DTOs.Base.Validators;

namespace SchoolManagement.Application.Features.Bases.Handlers.Commands
{
    public class UpdateBaseCommandHandler : IRequestHandler<UpdateBaseCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateBaseCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateBaseCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateBaseDtoValidator(); 
             var validationResult = await validator.ValidateAsync(request.BasemDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var Base = await _unitOfWork.Repository<Base>().Get(request.BasemDto.BaseId);

            if (Base is null)
                throw new NotFoundException(nameof(Base), request.BasemDto.BaseId);

            _mapper.Map(request.BasemDto, Base);

            await _unitOfWork.Repository<Base>().Update(Base);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
