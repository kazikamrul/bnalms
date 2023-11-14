using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.AuthorInformation.Validators;
using SchoolManagement.Application.Features.AuthorInformations.Requests.Commands;
using SchoolManagement.Application.Responses;
using SchoolManagement.Domain;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.AuthorInformations.Handlers.Commands
{
    public class CreateAuthorInformationCommandHandler : IRequestHandler<CreateAuthorInformationCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateAuthorInformationCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateAuthorInformationCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateAuthorInformationDtoValidator();
            var validationResult = await validator.ValidateAsync(request.AuthorInformationDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var AuthorInformation = _mapper.Map<AuthorInformation>(request.AuthorInformationDto);

                AuthorInformation = await _unitOfWork.Repository<AuthorInformation>().Add(AuthorInformation);

                try
                {
                    await _unitOfWork.Save();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }


                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = AuthorInformation.AuthorInformationId;
            }

            return response;
        }
    }
}
