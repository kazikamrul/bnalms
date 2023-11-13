using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.FeeInformation.Validators;
using SchoolManagement.Application.Features.FeeInformations.Requests.Commands;
using SchoolManagement.Application.Responses;
using SchoolManagement.Domain;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.FeeInformations.Handlers.Commands
{
    public class CreateFeeInformationCommandHandler : IRequestHandler<CreateFeeInformationCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateFeeInformationCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateFeeInformationCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateFeeInformationDtoValidator();
            var validationResult = await validator.ValidateAsync(request.FeeInformationDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var FeeInformation = _mapper.Map<FeeInformation>(request.FeeInformationDto);

                FeeInformation = await _unitOfWork.Repository<FeeInformation>().Add(FeeInformation);
                FeeInformation.PaidDate = FeeInformation.PaidDate.Value.AddDays(1.0);
                if(FeeInformation.ExpiredDate != null)
                {
                    FeeInformation.ExpiredDate = FeeInformation.ExpiredDate.Value.AddDays(1.0);
                }
                //FeeInformation.ExpiredDate = FeeInformation.ExpiredDate.Value.AddDays(1.0);
                await _unitOfWork.Save();

                //update memberinfo table
                var MemberInfos = await _unitOfWork.Repository<MemberInfo>().Get((int)request.FeeInformationDto.MemberInfoId);
               
                MemberInfos.ExpireDate = request.FeeInformationDto.ExpiredDate;

                if (request.FeeInformationDto.ExpiredDate != null)
                {
                    MemberInfos.ExpireDate = MemberInfos.ExpireDate.Value.AddDays(1.0);
                }

                await _unitOfWork.Repository<MemberInfo>().Update(MemberInfos);

                //MemberInfos.ExpireDate = MemberInfos.ExpireDate.Value.AddDays(1.0);
                await _unitOfWork.Save();


                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = FeeInformation.FeeInformationId;
            }

            return response;
        }
    }
}
