using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.MemberRegistration.Validators;
using SchoolManagement.Application.Features.MemberRegistrations.Requests.Commands;
using SchoolManagement.Application.Responses;
using SchoolManagement.Domain;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.MemberRegistrations.Handlers.Commands
{
    public class CreateMemberRegistrationCommandHandler : IRequestHandler<CreateMemberRegistrationCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateMemberRegistrationCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateMemberRegistrationCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateMemberRegistrationDtoValidator();
            var validationResult = await validator.ValidateAsync(request.MemberRegistrationDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var MemberRegistration = _mapper.Map<MemberRegistration>(request.MemberRegistrationDto);

                MemberRegistration = await _unitOfWork.Repository<MemberRegistration>().Add(MemberRegistration);
                try
                {
                    await _unitOfWork.Save();
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex);
                }
               


                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = MemberRegistration.MemberRegistrationId;
            }

            return response;
        }
    }
}
