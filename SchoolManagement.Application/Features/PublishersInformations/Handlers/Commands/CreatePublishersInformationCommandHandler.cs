using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.PublishersInformation.Validators;
using SchoolManagement.Application.Features.PublishersInformations.Requests.Commands;
using SchoolManagement.Application.Responses;
using SchoolManagement.Domain;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.PublishersInformations.Handlers.Commands
{
    public class CreatePublishersInformationCommandHandler : IRequestHandler<CreatePublishersInformationCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreatePublishersInformationCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreatePublishersInformationCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreatePublishersInformationDtoValidator();
            var validationResult = await validator.ValidateAsync(request.PublishersInformationDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var PublishersInformation = _mapper.Map<PublishersInformation>(request.PublishersInformationDto);

                PublishersInformation = await _unitOfWork.Repository<PublishersInformation>().Add(PublishersInformation);
                await _unitOfWork.Save();


                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = PublishersInformation.PublishersInformationId;
            }

            return response;
        }
    }
}
