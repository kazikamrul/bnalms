using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.ShelfInfo.Validators;
using SchoolManagement.Application.Features.ShelfInfos.Requests.Commands;
using SchoolManagement.Application.Responses;
using SchoolManagement.Domain;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.ShelfInfos.Handlers.Commands
{
    public class CreateShelfInfoCommandHandler : IRequestHandler<CreateShelfInfoCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateShelfInfoCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateShelfInfoCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateShelfInfoDtoValidator();
            var validationResult = await validator.ValidateAsync(request.ShelfInfoDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var ShelfInfo = _mapper.Map<ShelfInfo>(request.ShelfInfoDto);

                ShelfInfo = await _unitOfWork.Repository<ShelfInfo>().Add(ShelfInfo);
                await _unitOfWork.Save();


                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = ShelfInfo.ShelfInfoId;
            }

            return response;
        }
    }
}
