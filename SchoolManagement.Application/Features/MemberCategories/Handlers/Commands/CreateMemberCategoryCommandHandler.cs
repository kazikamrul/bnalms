using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.MemberCategory.Validators;
using SchoolManagement.Application.Features.MemberCategorys.Requests.Commands;
using SchoolManagement.Application.Responses;
using SchoolManagement.Domain;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.MemberCategorys.Handlers.Commands
{
    public class CreateMemberCategoryCommandHandler : IRequestHandler<CreateMemberCategoryCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateMemberCategoryCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateMemberCategoryCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateMemberCategoryDtoValidator();
            var validationResult = await validator.ValidateAsync(request.MemberCategoryDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var MemberCategory = _mapper.Map<MemberCategory>(request.MemberCategoryDto);

                MemberCategory = await _unitOfWork.Repository<MemberCategory>().Add(MemberCategory);
                await _unitOfWork.Save();


                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = MemberCategory.MemberCategoryId;
            }

            return response;
        }
    }
}
