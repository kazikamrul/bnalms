using SchoolManagement.Domain;
using AutoMapper;
using MediatR;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Contracts.Persistence;
using System.Threading;
using System.Threading.Tasks;
using SchoolManagement.Application.Features.BookBindingInfos.Requests.Commands;
using SchoolManagement.Application.DTOs.BookBindingInfo.Validators;

namespace SchoolManagement.Application.Features.BookBindingInfos.Handlers.Commands
{
    public class UpdateBookBindingInfoCommandHandler : IRequestHandler<UpdateBookBindingInfoCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateBookBindingInfoCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateBookBindingInfoCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateBookBindingInfoDtoValidator(); 
             var validationResult = await validator.ValidateAsync(request.BookBindingInfoDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var BookBindingInfo = await _unitOfWork.Repository<BookBindingInfo>().Get(request.BookBindingInfoDto.BookBindingInfoId);

            if (BookBindingInfo is null)
                throw new NotFoundException(nameof(BookBindingInfo), request.BookBindingInfoDto.BookBindingInfoId);

            _mapper.Map(request.BookBindingInfoDto, BookBindingInfo);

            await _unitOfWork.Repository<BookBindingInfo>().Update(BookBindingInfo);
            BookBindingInfo.Date = BookBindingInfo.Date.Value.AddDays(1.0);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
