using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.BookBindingInfos.Requests.Commands;
using SchoolManagement.Application.Features.BookIssueAndSubmissions.Requests.Commands;
using SchoolManagement.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.BookBindingInfos.Handlers.Commands
{
    public class ReturnBookBindingInfoCommandHandler : IRequestHandler<ReturnBookBindingCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ReturnBookBindingInfoCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(ReturnBookBindingCommand request, CancellationToken cancellationToken)
        {
            var BookInfo = await _unitOfWork.Repository<BookInformation>().Get(request.BookInformationId);

            BookInfo.BookBindingStatus = 0;
            BookInfo.IssueStatus = 0;

            await _unitOfWork.Repository<BookInformation>().Update(BookInfo);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
