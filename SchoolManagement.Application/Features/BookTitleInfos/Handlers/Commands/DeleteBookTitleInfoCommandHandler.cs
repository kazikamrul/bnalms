using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.BookTitleInfos.Requests.Commands;
using SchoolManagement.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.BookTitleInfos.Handlers.Commands
{
    public class DeleteBookTitleInfoCommandHandler : IRequestHandler<DeleteBookTitleInfoCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteBookTitleInfoCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteBookTitleInfoCommand request, CancellationToken cancellationToken)
        {
            var BookTitleInfo = await _unitOfWork.Repository<BookTitleInfo>().Get(request.BookTitleInfoId);

            if (BookTitleInfo == null)
                throw new NotFoundException(nameof(BookTitleInfo), request.BookTitleInfoId);

            await _unitOfWork.Repository<BookTitleInfo>().Delete(BookTitleInfo);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
