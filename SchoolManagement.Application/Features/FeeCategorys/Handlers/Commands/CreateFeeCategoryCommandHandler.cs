using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.FeeCategory.Validators;
using SchoolManagement.Application.Features.FeeCategorys.Requests.Commands;
using SchoolManagement.Application.Responses;
using SchoolManagement.Domain;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.FeeCategorys.Handlers.Commands
{
    public class CreateFeeCategoryCommandHandler : IRequestHandler<CreateFeeCategoryCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateFeeCategoryCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateFeeCategoryCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateFeeCategoryDtoValidator();
            var validationResult = await validator.ValidateAsync(request.FeeCategoryDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var FeeCategory = _mapper.Map<FeeCategory>(request.FeeCategoryDto);

                FeeCategory = await _unitOfWork.Repository<FeeCategory>().Add(FeeCategory);
                try
                {
                    await _unitOfWork.Save();
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex);
                }
                


                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = FeeCategory.FeeCategoryId;
            }

            return response;
        }
    }
}
