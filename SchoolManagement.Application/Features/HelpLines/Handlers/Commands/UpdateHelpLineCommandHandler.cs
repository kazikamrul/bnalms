using SchoolManagement.Domain;
using AutoMapper;
using MediatR;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Contracts.Persistence;
using System.Threading;
using System.Threading.Tasks;
using SchoolManagement.Application.Features.HelpLines.Requests.Commands;
using SchoolManagement.Application.DTOs.HelpLine.Validators;

namespace SchoolManagement.Application.Features.HelpLines.Handlers.Commands
{
    public class UpdateHelpLineCommandHandler : IRequestHandler<UpdateHelpLineCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateHelpLineCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateHelpLineCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateHelpLineDtoValidator(); 
             var validationResult = await validator.ValidateAsync(request.HelpLineDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var HelpLine = await _unitOfWork.Repository<HelpLine>().Get(request.HelpLineDto.HelpLineId);

            if (HelpLine is null)
                throw new NotFoundException(nameof(HelpLine), request.HelpLineDto.HelpLineId);

            _mapper.Map(request.HelpLineDto, HelpLine);

            await _unitOfWork.Repository<HelpLine>().Update(HelpLine);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
