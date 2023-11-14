using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.LibraryAuthoritys.Requests.Commands;
using SchoolManagement.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.LibraryAuthoritys.Handlers.Commands
{
    public class DeleteLibraryAuthorityCommandHandler : IRequestHandler<DeleteLibraryAuthorityCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteLibraryAuthorityCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteLibraryAuthorityCommand request, CancellationToken cancellationToken)
        {
            var LibraryAuthority = await _unitOfWork.Repository<LibraryAuthority>().Get(request.LibraryAuthorityId);

            if (LibraryAuthority == null)
                throw new NotFoundException(nameof(LibraryAuthority), request.LibraryAuthorityId);

            await _unitOfWork.Repository<LibraryAuthority>().Delete(LibraryAuthority);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
