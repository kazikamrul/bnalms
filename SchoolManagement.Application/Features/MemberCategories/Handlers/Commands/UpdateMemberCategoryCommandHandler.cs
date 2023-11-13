using SchoolManagement.Domain;
using AutoMapper;
using MediatR;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Contracts.Persistence;
using System.Threading;
using System.Threading.Tasks;
using SchoolManagement.Application.DTOs.MemberCategory.Validators;
using SchoolManagement.Application.Features.MemberCategorys.Requests.Commands;

namespace SchoolManagement.Application.Features.MemberCategorys.Handlers.Commands
{
    public class UpdateMemberCategoryCommandHandler : IRequestHandler<UpdateMemberCategoryCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateMemberCategoryCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateMemberCategoryCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateMemberCategoryDtoValidator(); 
             var validationResult = await validator.ValidateAsync(request.MemberCategoryDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var MemberCategory = await _unitOfWork.Repository<MemberCategory>().Get(request.MemberCategoryDto.MemberCategoryId);

            if (MemberCategory is null)
                throw new NotFoundException(nameof(MemberCategory), request.MemberCategoryDto.MemberCategoryId);

            _mapper.Map(request.MemberCategoryDto, MemberCategory);

            await _unitOfWork.Repository<MemberCategory>().Update(MemberCategory);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
