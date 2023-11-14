using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.DamageInformationByLibrary.Validators;
using SchoolManagement.Application.Features.DamageInformationByLibrarys.Requests.Commands;
using SchoolManagement.Application.Responses;
using SchoolManagement.Domain;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.DamageInformationByLibrarys.Handlers.Commands
{
    public class CreateDamageInformationByLibraryCommandHandler : IRequestHandler<CreateDamageInformationByLibraryCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateDamageInformationByLibraryCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateDamageInformationByLibraryCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateDamageInformationByLibraryDtoValidator();
            var validationResult = await validator.ValidateAsync(request.DamageInformationByLibraryDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var DamageInformationByLibrary = _mapper.Map<DamageInformationByLibrary>(request.DamageInformationByLibraryDto);

                DamageInformationByLibrary = await _unitOfWork.Repository<DamageInformationByLibrary>().Add(DamageInformationByLibrary);
                await _unitOfWork.Save();


                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = DamageInformationByLibrary.DamageInformationByLibraryId;
            }

            return response;
        }
    }
}
