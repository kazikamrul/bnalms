using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.SupplierInformation.Validators;
using SchoolManagement.Application.Features.SupplierInformations.Requests.Commands;
using SchoolManagement.Application.Responses;
using SchoolManagement.Domain;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.SupplierInformations.Handlers.Commands
{
    public class CreateSupplierInformationCommandHandler : IRequestHandler<CreateSupplierInformationCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateSupplierInformationCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateSupplierInformationCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateSupplierInformationDtoValidator();
            var validationResult = await validator.ValidateAsync(request.SupplierInformationDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var SupplierInformation = _mapper.Map<SupplierInformation>(request.SupplierInformationDto);

                SupplierInformation = await _unitOfWork.Repository<SupplierInformation>().Add(SupplierInformation);
                SupplierInformation.SuppliedDate = SupplierInformation.SuppliedDate.Value.AddDays(1.0);
                SupplierInformation.ReceivedDate = SupplierInformation.ReceivedDate.Value.AddDays(1.0);

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
                response.Id = SupplierInformation.SupplierInformationId;
            }

            return response;
        }
    }
}
