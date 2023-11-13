using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.BookIssueAndSubmissions.Requests.Commands;
using SchoolManagement.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.BookIssueAndSubmissions.Handlers.Commands
{
    public class ReturnBookIssueAndSubmissionCommandHandler : IRequestHandler<ReturnBookIssueAndSubmissionCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ReturnBookIssueAndSubmissionCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(ReturnBookIssueAndSubmissionCommand request, CancellationToken cancellationToken)
        {
            var BookIssueAndSubmission = await _unitOfWork.Repository<BookIssueAndSubmission>().Get(request.BookIssueAndSubmissionId);
            

            if (BookIssueAndSubmission == null)
                throw new NotFoundException(nameof(BookIssueAndSubmission), request.BookIssueAndSubmissionId);

            var BookInfo = await _unitOfWork.Repository<BookInformation>().Get((int)BookIssueAndSubmission.BookInformationId);
            if (BookInfo == null)
                throw new NotFoundException(nameof(BookInfo), (int)BookIssueAndSubmission.BookInformationId);

          
            if (request.ReturnStatus == 1)
            {
                BookIssueAndSubmission.ReturnStatus = 1;
                BookIssueAndSubmission.SubmissionDate = DateTime.Now;
                BookInfo.IssueStatus = 0; 
                BookInfo.MemberInfoId = null;

                await _unitOfWork.Repository<BookIssueAndSubmission>().Update(BookIssueAndSubmission);
                await _unitOfWork.Repository<BookInformation>().Update(BookInfo);
                await _unitOfWork.Save();

                return Unit.Value;
            }
            else if(request.ReturnStatus == 2)
            {
                BookIssueAndSubmission.BorrowerDamageStatus = 1;
                await _unitOfWork.Repository<BookIssueAndSubmission>().Update(BookIssueAndSubmission);
                await _unitOfWork.Repository<BookInformation>().Update(BookInfo);
                await _unitOfWork.Save();

                return Unit.Value;
            }
            else
            {
                return Unit.Value;
            }

            
        }
    }
}
