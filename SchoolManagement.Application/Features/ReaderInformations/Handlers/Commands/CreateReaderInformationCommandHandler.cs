using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.ReaderInformation.Validators;
using SchoolManagement.Application.Features.ReaderInformations.Requests.Commands;
using SchoolManagement.Application.Responses;
using SchoolManagement.Domain;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.ReaderInformations.Handlers.Commands
{
    public class CreateReaderInformationCommandHandler : IRequestHandler<CreateReaderInformationCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateReaderInformationCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateReaderInformationCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateReaderInformationDtoValidator();
            var validationResult = await validator.ValidateAsync(request.ReaderInformationDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var ReaderInformation = _mapper.Map<ReaderInformation>(request.ReaderInformationDto);

                ReaderInformation = await _unitOfWork.Repository<ReaderInformation>().Add(ReaderInformation);
                await _unitOfWork.Save();


                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = ReaderInformation.ReaderInformationId;
            }

            return response;
        }
    }
}
