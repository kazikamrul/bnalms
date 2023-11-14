using SchoolManagement.Domain;
using AutoMapper;
using MediatR;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Contracts.Persistence;
using System.Threading;
using System.Threading.Tasks;
using SchoolManagement.Application.Features.Areas.Requests.Commands;
using SchoolManagement.Application.DTOs.Area.Validators;

namespace SchoolManagement.Application.Features.Areas.Handlers.Commands
{
    public class UpdateAreaCommandHandler : IRequestHandler<UpdateAreaCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateAreaCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateAreaCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateAreaDtoValidator(); 
             var validationResult = await validator.ValidateAsync(request.AreaDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var Area = await _unitOfWork.Repository<Area>().Get(request.AreaDto.AreaId);

            if (Area is null)
                throw new NotFoundException(nameof(Area), request.AreaDto.AreaId);

            _mapper.Map(request.AreaDto, Area);

            await _unitOfWork.Repository<Area>().Update(Area);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
