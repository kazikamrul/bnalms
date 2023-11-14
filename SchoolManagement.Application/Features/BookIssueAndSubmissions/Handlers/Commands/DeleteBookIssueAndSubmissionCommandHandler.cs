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
    public class DeleteBookIssueAndSubmissionCommandHandler : IRequestHandler<DeleteBookIssueAndSubmissionCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteBookIssueAndSubmissionCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteBookIssueAndSubmissionCommand request, CancellationToken cancellationToken)
        {
            var BookIssueAndSubmission = await _unitOfWork.Repository<BookIssueAndSubmission>().Get(request.BookIssueAndSubmissionId);

            if (BookIssueAndSubmission == null)
                throw new NotFoundException(nameof(BookIssueAndSubmission), request.BookIssueAndSubmissionId);

            await _unitOfWork.Repository<BookIssueAndSubmission>().Delete(BookIssueAndSubmission);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
