using SchoolManagement.Domain;
using AutoMapper;
using MediatR;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Contracts.Persistence;
using System.Threading;
using System.Threading.Tasks;
using SchoolManagement.Application.Features.MemberRegistrations.Requests.Commands;
using SchoolManagement.Application.DTOs.MemberRegistration.Validators;

namespace SchoolManagement.Application.Features.MemberRegistrations.Handlers.Commands
{
    public class UpdateMemberRegistrationCommandHandler : IRequestHandler<UpdateMemberRegistrationCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateMemberRegistrationCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateMemberRegistrationCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateMemberRegistrationDtoValidator(); 
             var validationResult = await validator.ValidateAsync(request.MemberRegistrationDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var MemberRegistration = await _unitOfWork.Repository<MemberRegistration>().Get(request.MemberRegistrationDto.MemberRegistrationId);

            if (MemberRegistration is null)
                throw new NotFoundException(nameof(MemberRegistration), request.MemberRegistrationDto.MemberRegistrationId);

            _mapper.Map(request.MemberRegistrationDto, MemberRegistration);

            await _unitOfWork.Repository<MemberRegistration>().Update(MemberRegistration);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
