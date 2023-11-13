using SchoolManagement.Domain;
using AutoMapper;
using MediatR;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Contracts.Persistence;
using System.Threading;
using System.Threading.Tasks;
using SchoolManagement.Application.Features.LibraryAuthoritys.Requests.Commands;
using SchoolManagement.Application.DTOs.LibraryAuthority.Validators;

namespace SchoolManagement.Application.Features.LibraryAuthoritys.Handlers.Commands
{
    public class UpdateLibraryAuthorityCommandHandler : IRequestHandler<UpdateLibraryAuthorityCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateLibraryAuthorityCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateLibraryAuthorityCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateLibraryAuthorityDtoValidator(); 
             var validationResult = await validator.ValidateAsync(request.LibraryAuthorityDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var LibraryAuthority = await _unitOfWork.Repository<LibraryAuthority>().Get(request.LibraryAuthorityDto.LibraryAuthorityId);

            if (LibraryAuthority is null)
                throw new NotFoundException(nameof(LibraryAuthority), request.LibraryAuthorityDto.LibraryAuthorityId);

            _mapper.Map(request.LibraryAuthorityDto, LibraryAuthority);

            await _unitOfWork.Repository<LibraryAuthority>().Update(LibraryAuthority);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
