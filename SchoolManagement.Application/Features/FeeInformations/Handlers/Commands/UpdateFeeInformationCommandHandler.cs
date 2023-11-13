using SchoolManagement.Domain;
using AutoMapper;
using MediatR;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Contracts.Persistence;
using System.Threading;
using System.Threading.Tasks;
using SchoolManagement.Application.Features.FeeInformations.Requests.Commands;
using SchoolManagement.Application.DTOs.FeeInformation.Validators;

namespace SchoolManagement.Application.Features.FeeInformations.Handlers.Commands
{
    public class UpdateFeeInformationCommandHandler : IRequestHandler<UpdateFeeInformationCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateFeeInformationCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateFeeInformationCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateFeeInformationDtoValidator(); 
             var validationResult = await validator.ValidateAsync(request.FeeInformationDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var FeeInformation = await _unitOfWork.Repository<FeeInformation>().Get(request.FeeInformationDto.FeeInformationId);

            if (FeeInformation is null)
                throw new NotFoundException(nameof(FeeInformation), request.FeeInformationDto.FeeInformationId);

            _mapper.Map(request.FeeInformationDto, FeeInformation);

            await _unitOfWork.Repository<FeeInformation>().Update(FeeInformation);
            await _unitOfWork.Save();

            //update memberinfo table
            var MemberInfos = await _unitOfWork.Repository<MemberInfo>().Get((int)request.FeeInformationDto.MemberInfoId);

            MemberInfos.ExpireDate = request.FeeInformationDto.PaidDate;

            await _unitOfWork.Repository<MemberInfo>().Update(MemberInfos);

            await _unitOfWork.Save();
            return Unit.Value;
        }
    }
}
