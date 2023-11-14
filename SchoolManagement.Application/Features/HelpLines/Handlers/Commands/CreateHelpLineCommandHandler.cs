using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.HelpLine.Validators;
using SchoolManagement.Application.Features.HelpLines.Requests.Commands;
using SchoolManagement.Application.Responses;
using SchoolManagement.Domain;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.HelpLines.Handlers.Commands
{
    public class CreateHelpLineCommandHandler : IRequestHandler<CreateHelpLineCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateHelpLineCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateHelpLineCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateHelpLineDtoValidator();
            var validationResult = await validator.ValidateAsync(request.HelpLineDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var HelpLine = _mapper.Map<HelpLine>(request.HelpLineDto);

                HelpLine = await _unitOfWork.Repository<HelpLine>().Add(HelpLine);
                await _unitOfWork.Save();


                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = HelpLine.HelpLineId;
            }

            return response;
        }
    }
}
