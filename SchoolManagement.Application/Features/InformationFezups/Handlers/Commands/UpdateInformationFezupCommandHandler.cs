using SchoolManagement.Domain;
using AutoMapper;
using MediatR;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Contracts.Persistence;
using System.Threading;
using System.Threading.Tasks;
using SchoolManagement.Application.Features.InformationFezups.Requests.Commands;
using SchoolManagement.Application.DTOs.InformationFezup.Validators;

namespace SchoolManagement.Application.Features.InformationFezups.Handlers.Commands
{
    public class UpdateInformationFezupCommandHandler : IRequestHandler<UpdateInformationFezupCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateInformationFezupCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateInformationFezupCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateInformationFezupDtoValidator(); 
             var validationResult = await validator.ValidateAsync(request.InformationFezupDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var InformationFezup = await _unitOfWork.Repository<InformationFezup>().Get(request.InformationFezupDto.InformationFezupId);

            if (InformationFezup is null)
                throw new NotFoundException(nameof(InformationFezup), request.InformationFezupDto.InformationFezupId);

            _mapper.Map(request.InformationFezupDto, InformationFezup);

            await _unitOfWork.Repository<InformationFezup>().Update(InformationFezup);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
