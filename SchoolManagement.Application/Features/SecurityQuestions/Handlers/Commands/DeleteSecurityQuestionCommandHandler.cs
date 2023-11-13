using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.SecurityQuestions.Requests.Commands;
using SchoolManagement.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.SecurityQuestions.Handlers.Commands
{
    public class DeleteSecurityQuestionCommandHandler : IRequestHandler<DeleteSecurityQuestionCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteSecurityQuestionCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteSecurityQuestionCommand request, CancellationToken cancellationToken)
        {
            var SecurityQuestion = await _unitOfWork.Repository<SecurityQuestion>().Get(request.SecurityQuestionId);

            if (SecurityQuestion == null)
                throw new NotFoundException(nameof(SecurityQuestion), request.SecurityQuestionId);

            await _unitOfWork.Repository<SecurityQuestion>().Delete(SecurityQuestion);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
