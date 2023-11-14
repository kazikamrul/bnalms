using SchoolManagement.Domain;
using AutoMapper;
using MediatR;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Contracts.Persistence;
using System.Threading;
using System.Threading.Tasks;
using SchoolManagement.Application.Features.DamageInformationByLibrarys.Requests.Commands;
using SchoolManagement.Application.DTOs.DamageInformationByLibrary.Validators;

namespace SchoolManagement.Application.Features.DamageInformationByLibrarys.Handlers.Commands
{
    public class UpdateDamageInformationByLibraryCommandHandler : IRequestHandler<UpdateDamageInformationByLibraryCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateDamageInformationByLibraryCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateDamageInformationByLibraryCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateDamageInformationByLibraryDtoValidator(); 
             var validationResult = await validator.ValidateAsync(request.DamageInformationByLibraryDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var DamageInformationByLibrary = await _unitOfWork.Repository<DamageInformationByLibrary>().Get(request.DamageInformationByLibraryDto.DamageInformationByLibraryId);

            if (DamageInformationByLibrary is null)
                throw new NotFoundException(nameof(DamageInformationByLibrary), request.DamageInformationByLibraryDto.DamageInformationByLibraryId);

            _mapper.Map(request.DamageInformationByLibraryDto, DamageInformationByLibrary);

            await _unitOfWork.Repository<DamageInformationByLibrary>().Update(DamageInformationByLibrary);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
