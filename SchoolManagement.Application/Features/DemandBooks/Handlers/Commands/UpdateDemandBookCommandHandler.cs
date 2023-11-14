using SchoolManagement.Domain;
using AutoMapper;
using MediatR;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Contracts.Persistence;
using System.Threading;
using System.Threading.Tasks;
using SchoolManagement.Application.Features.DemandBooks.Requests.Commands;
using SchoolManagement.Application.DTOs.DemandBook.Validators;

namespace SchoolManagement.Application.Features.DemandBooks.Handlers.Commands
{
    public class UpdateDemandBookCommandHandler : IRequestHandler<UpdateDemandBookCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateDemandBookCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateDemandBookCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateDemandBookDtoValidator(); 
             var validationResult = await validator.ValidateAsync(request.DemandBookDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var DemandBook = await _unitOfWork.Repository<DemandBook>().Get(request.DemandBookDto.DemandBookId);

            if (DemandBook is null)
                throw new NotFoundException(nameof(DemandBook), request.DemandBookDto.DemandBookId);

            _mapper.Map(request.DemandBookDto, DemandBook);

            await _unitOfWork.Repository<DemandBook>().Update(DemandBook);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
