using SchoolManagement.Domain;
using AutoMapper;
using MediatR;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Contracts.Persistence;
using System.Threading;
using System.Threading.Tasks;
using SchoolManagement.Application.Features.AuthorityCategorys.Requests.Commands;
using SchoolManagement.Application.DTOs.AuthorityCategory.Validators;

namespace SchoolManagement.Application.Features.AuthorityCategorys.Handlers.Commands
{
    public class UpdateAuthorityCategoryCommandHandler : IRequestHandler<UpdateAuthorityCategoryCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateAuthorityCategoryCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateAuthorityCategoryCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateAuthorityCategoryDtoValidator(); 
             var validationResult = await validator.ValidateAsync(request.AuthorityCategoryDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var AuthorityCategory = await _unitOfWork.Repository<AuthorityCategory>().Get(request.AuthorityCategoryDto.AuthorityCategoryId);

            if (AuthorityCategory is null)
                throw new NotFoundException(nameof(AuthorityCategory), request.AuthorityCategoryDto.AuthorityCategoryId);

            _mapper.Map(request.AuthorityCategoryDto, AuthorityCategory);

            await _unitOfWork.Repository<AuthorityCategory>().Update(AuthorityCategory);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
