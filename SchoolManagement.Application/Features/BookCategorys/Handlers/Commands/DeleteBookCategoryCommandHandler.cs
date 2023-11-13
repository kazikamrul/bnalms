using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.BookCategorys.Requests.Commands;
using SchoolManagement.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.BookCategorys.Handlers.Commands
{
    public class DeleteBookCategoryCommandHandler : IRequestHandler<DeleteBookCategoryCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteBookCategoryCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteBookCategoryCommand request, CancellationToken cancellationToken)
        {
            var BookCategory = await _unitOfWork.Repository<BookCategory>().Get(request.BookCategoryId);

            if (BookCategory == null)
                throw new NotFoundException(nameof(BookCategory), request.BookCategoryId);

            await _unitOfWork.Repository<BookCategory>().Delete(BookCategory);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
