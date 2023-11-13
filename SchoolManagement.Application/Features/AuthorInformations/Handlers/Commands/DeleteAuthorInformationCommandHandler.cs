using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.AuthorInformations.Requests.Commands;
using SchoolManagement.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.AuthorInformations.Handlers.Commands
{
    public class DeleteAuthorInformationCommandHandler : IRequestHandler<DeleteAuthorInformationCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteAuthorInformationCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteAuthorInformationCommand request, CancellationToken cancellationToken)
        {
            var AuthorInformation = await _unitOfWork.Repository<AuthorInformation>().Get(request.AuthorInformationId);

            if (AuthorInformation == null)
                throw new NotFoundException(nameof(AuthorInformation), request.AuthorInformationId);

            await _unitOfWork.Repository<AuthorInformation>().Delete(AuthorInformation);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
