using SchoolManagement.Domain;
using AutoMapper;
using MediatR;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Contracts.Persistence;
using System.Threading;
using System.Threading.Tasks;
using SchoolManagement.Application.Features.BookCategorys.Requests.Commands;
using SchoolManagement.Application.DTOs.BookCategory.Validators;

namespace SchoolManagement.Application.Features.BookCategorys.Handlers.Commands
{
    public class UpdateBookCategoryCommandHandler : IRequestHandler<UpdateBookCategoryCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateBookCategoryCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateBookCategoryCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateBookCategoryDtoValidator(); 
             var validationResult = await validator.ValidateAsync(request.BookCategoryDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var BookCategory = await _unitOfWork.Repository<BookCategory>().Get(request.BookCategoryDto.BookCategoryId);

            if (BookCategory is null)
                throw new NotFoundException(nameof(BookCategory), request.BookCategoryDto.BookCategoryId);

            _mapper.Map(request.BookCategoryDto, BookCategory);

            await _unitOfWork.Repository<BookCategory>().Update(BookCategory);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
