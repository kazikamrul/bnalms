using SchoolManagement.Domain;
using AutoMapper;
using MediatR;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Contracts.Persistence;
using System.Threading;
using System.Threading.Tasks;
using SchoolManagement.Application.Features.Sources.Requests.Commands;
using SchoolManagement.Application.DTOs.Source.Validators;

namespace SchoolManagement.Application.Features.Sources.Handlers.Commands
{
    public class UpdateSourceCommandHandler : IRequestHandler<UpdateSourceCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateSourceCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateSourceCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateSourceDtoValidator(); 
             var validationResult = await validator.ValidateAsync(request.SourceDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var Source = await _unitOfWork.Repository<Source>().Get(request.SourceDto.SourceId);

            if (Source is null)
                throw new NotFoundException(nameof(Source), request.SourceDto.SourceId);

            _mapper.Map(request.SourceDto, Source);

            await _unitOfWork.Repository<Source>().Update(Source);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
