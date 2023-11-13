using SchoolManagement.Domain;
using AutoMapper;
using MediatR;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Contracts.Persistence;
using System.Threading;
using System.Threading.Tasks;
using SchoolManagement.Application.Features.MainClasses.Requests.Commands;
using SchoolManagement.Application.DTOs.MainClass.Validators;

namespace SchoolManagement.Application.Features.MainClasses.Handlers.Commands
{
    public class UpdateMainClassCommandHandler : IRequestHandler<UpdateMainClassCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateMainClassCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateMainClassCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateMainClassDtoValidator(); 
             var validationResult = await validator.ValidateAsync(request.MainClassDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var MainClass = await _unitOfWork.Repository<MainClass>().Get(request.MainClassDto.MainClassId);

            if (MainClass is null)
                throw new NotFoundException(nameof(MainClass), request.MainClassDto.MainClassId);

            _mapper.Map(request.MainClassDto, MainClass);

            await _unitOfWork.Repository<MainClass>().Update(MainClass);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
