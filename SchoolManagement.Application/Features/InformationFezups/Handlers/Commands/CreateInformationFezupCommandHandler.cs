using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.InformationFezup.Validators;
using SchoolManagement.Application.Features.InformationFezups.Requests.Commands;
using SchoolManagement.Application.Responses;
using SchoolManagement.Domain;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.InformationFezups.Handlers.Commands
{
    public class CreateInformationFezupCommandHandler : IRequestHandler<CreateInformationFezupCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateInformationFezupCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateInformationFezupCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateInformationFezupDtoValidator();
            var validationResult = await validator.ValidateAsync(request.InformationFezupDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var InformationFezup = _mapper.Map<InformationFezup>(request.InformationFezupDto);

                InformationFezup = await _unitOfWork.Repository<InformationFezup>().Add(InformationFezup);
                await _unitOfWork.Save();


                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = InformationFezup.InformationFezupId;
            }

            return response;
        }
    }
}
