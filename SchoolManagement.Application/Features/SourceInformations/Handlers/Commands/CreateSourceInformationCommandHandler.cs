using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.SourceInformation.Validators;
using SchoolManagement.Application.Features.SourceInformations.Requests.Commands;
using SchoolManagement.Application.Responses;
using SchoolManagement.Domain;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.SourceInformations.Handlers.Commands
{
    public class CreateSourceInformationCommandHandler : IRequestHandler<CreateSourceInformationCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateSourceInformationCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateSourceInformationCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateSourceInformationDtoValidator();
            var validationResult = await validator.ValidateAsync(request.SourceInformationDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var SourceInformation = _mapper.Map<SourceInformation>(request.SourceInformationDto);

                SourceInformation = await _unitOfWork.Repository<SourceInformation>().Add(SourceInformation);
                SourceInformation.OrderDate = SourceInformation.OrderDate.Value.AddDays(1.0);
                SourceInformation.ReceivedDate = SourceInformation.ReceivedDate.Value.AddDays(1.0);

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
                response.Id = SourceInformation.SourceInformationId;
            }

            return response;
        }
    }
}
