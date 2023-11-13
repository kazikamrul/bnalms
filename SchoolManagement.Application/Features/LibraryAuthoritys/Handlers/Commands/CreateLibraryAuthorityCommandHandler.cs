using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.LibraryAuthority.Validators;
using SchoolManagement.Application.Features.LibraryAuthoritys.Requests.Commands;
using SchoolManagement.Application.Responses;
using SchoolManagement.Domain;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.LibraryAuthoritys.Handlers.Commands
{
    public class CreateLibraryAuthorityCommandHandler : IRequestHandler<CreateLibraryAuthorityCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateLibraryAuthorityCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateLibraryAuthorityCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateLibraryAuthorityDtoValidator();
            var validationResult = await validator.ValidateAsync(request.LibraryAuthorityDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var LibraryAuthority = _mapper.Map<LibraryAuthority>(request.LibraryAuthorityDto);

                LibraryAuthority = await _unitOfWork.Repository<LibraryAuthority>().Add(LibraryAuthority);
                await _unitOfWork.Save();


                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = LibraryAuthority.LibraryAuthorityId;
            }

            return response;
        }
    }
}
