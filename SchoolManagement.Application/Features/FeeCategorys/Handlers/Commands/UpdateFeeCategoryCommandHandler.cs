using SchoolManagement.Domain;
using AutoMapper;
using MediatR;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Contracts.Persistence;
using System.Threading;
using System.Threading.Tasks;
using SchoolManagement.Application.Features.FeeCategorys.Requests.Commands;
using SchoolManagement.Application.DTOs.FeeCategory.Validators;

namespace SchoolManagement.Application.Features.FeeCategorys.Handlers.Commands
{
    public class UpdateFeeCategoryCommandHandler : IRequestHandler<UpdateFeeCategoryCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateFeeCategoryCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateFeeCategoryCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateFeeCategoryDtoValidator(); 
             var validationResult = await validator.ValidateAsync(request.FeeCategoryDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var FeeCategory = await _unitOfWork.Repository<FeeCategory>().Get(request.FeeCategoryDto.FeeCategoryId);

            if (FeeCategory is null)
                throw new NotFoundException(nameof(FeeCategory), request.FeeCategoryDto.FeeCategoryId);

            _mapper.Map(request.FeeCategoryDto, FeeCategory);

            await _unitOfWork.Repository<FeeCategory>().Update(FeeCategory);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
