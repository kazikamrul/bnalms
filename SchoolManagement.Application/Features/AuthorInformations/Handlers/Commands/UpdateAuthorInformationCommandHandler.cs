using SchoolManagement.Domain;
using AutoMapper;
using MediatR;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Contracts.Persistence;
using System.Threading;
using System.Threading.Tasks;
using SchoolManagement.Application.Features.AuthorInformations.Requests.Commands;
using SchoolManagement.Application.DTOs.AuthorInformation.Validators;

namespace SchoolManagement.Application.Features.AuthorInformations.Handlers.Commands
{
    public class UpdateAuthorInformationCommandHandler : IRequestHandler<UpdateAuthorInformationCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateAuthorInformationCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateAuthorInformationCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateAuthorInformationDtoValidator(); 
             var validationResult = await validator.ValidateAsync(request.AuthorInformationDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var AuthorInformation = await _unitOfWork.Repository<AuthorInformation>().Get(request.AuthorInformationDto.AuthorInformationId);

            if (AuthorInformation is null)
                throw new NotFoundException(nameof(AuthorInformation), request.AuthorInformationDto.AuthorInformationId);

            _mapper.Map(request.AuthorInformationDto, AuthorInformation);

            await _unitOfWork.Repository<AuthorInformation>().Update(AuthorInformation);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
