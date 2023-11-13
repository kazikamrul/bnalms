using SchoolManagement.Domain;
using AutoMapper;
using MediatR;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Contracts.Persistence;
using System.Threading;
using System.Threading.Tasks;
using SchoolManagement.Application.Features.NoticeTypes.Requests.Commands;
using SchoolManagement.Application.DTOs.NoticeType.Validators;

namespace SchoolManagement.Application.Features.NoticeTypes.Handlers.Commands
{
    public class UpdateNoticeTypeCommandHandler : IRequestHandler<UpdateNoticeTypeCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateNoticeTypeCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateNoticeTypeCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateNoticeTypeDtoValidator(); 
             var validationResult = await validator.ValidateAsync(request.NoticeTypeDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var NoticeType = await _unitOfWork.Repository<NoticeType>().Get(request.NoticeTypeDto.NoticeTypeId);

            if (NoticeType is null)
                throw new NotFoundException(nameof(NoticeType), request.NoticeTypeDto.NoticeTypeId);

            _mapper.Map(request.NoticeTypeDto, NoticeType);

            await _unitOfWork.Repository<NoticeType>().Update(NoticeType);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
