using SchoolManagement.Domain;
using AutoMapper;
using MediatR;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Contracts.Persistence;
using System.Threading;
using System.Threading.Tasks;
using SchoolManagement.Application.Features.BookTitleInfos.Requests.Commands;
using SchoolManagement.Application.DTOs.BookTitleInfo.Validators;

namespace SchoolManagement.Application.Features.BookTitleInfos.Handlers.Commands
{
    public class UpdateBookTitleInfoCommandHandler : IRequestHandler<UpdateBookTitleInfoCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateBookTitleInfoCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateBookTitleInfoCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateBookTitleInfoDtoValidator(); 
             var validationResult = await validator.ValidateAsync(request.BookTitleInfoDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var BookTitleInfo = await _unitOfWork.Repository<BookTitleInfo>().Get(request.BookTitleInfoDto.BookTitleInfoId);

            if (BookTitleInfo is null)
                throw new NotFoundException(nameof(BookTitleInfo), request.BookTitleInfoDto.BookTitleInfoId);

            _mapper.Map(request.BookTitleInfoDto, BookTitleInfo);

            await _unitOfWork.Repository<BookTitleInfo>().Update(BookTitleInfo);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
