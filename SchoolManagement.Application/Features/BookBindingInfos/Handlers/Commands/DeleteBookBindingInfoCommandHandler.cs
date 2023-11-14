using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.BookBindingInfos.Requests.Commands;
using SchoolManagement.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.BookBindingInfos.Handlers.Commands
{
    public class DeleteBookBindingInfoCommandHandler : IRequestHandler<DeleteBookBindingInfoCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteBookBindingInfoCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
         
        public async Task<Unit> Handle(DeleteBookBindingInfoCommand request, CancellationToken cancellationToken)
        {
            var BookBindingInfo = await _unitOfWork.Repository<BookBindingInfo>().Get(request.BookBindingInfoId);
             
            var bookInformation = await _unitOfWork.Repository<BookInformation>().Get(BookBindingInfo.BookInformationId.Value);
            bookInformation.BookBindingStatus = 0;
            bookInformation.IssueStatus = 0;

            if (BookBindingInfo == null)
                throw new NotFoundException(nameof(BookBindingInfo), request.BookBindingInfoId);

            await _unitOfWork.Repository<BookBindingInfo>().Delete(BookBindingInfo);

            await _unitOfWork.Repository<BookInformation>().Update(bookInformation);

            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
