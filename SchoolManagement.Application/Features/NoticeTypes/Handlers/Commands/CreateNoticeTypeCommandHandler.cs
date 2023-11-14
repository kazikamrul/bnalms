using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.NoticeType.Validators;
using SchoolManagement.Application.Features.NoticeTypes.Requests.Commands;
using SchoolManagement.Application.Responses;
using SchoolManagement.Domain;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.NoticeTypes.Handlers.Commands
{
    public class CreateNoticeTypeCommandHandler : IRequestHandler<CreateNoticeTypeCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateNoticeTypeCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
 
        public async Task<BaseCommandResponse> Handle(CreateNoticeTypeCommand request, CancellationToken cancellationToken)
        {   
            var response = new BaseCommandResponse();
            var validator = new CreateNoticeTypeDtoValidator();
            var validationResult = await validator.ValidateAsync(request.NoticeTypeDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var NoticeType = _mapper.Map<NoticeType>(request.NoticeTypeDto);

                NoticeType = await _unitOfWork.Repository<NoticeType>().Add(NoticeType);
                await _unitOfWork.Save();


                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = NoticeType.NoticeTypeId;
            }

            return response;
        }
    }
}
