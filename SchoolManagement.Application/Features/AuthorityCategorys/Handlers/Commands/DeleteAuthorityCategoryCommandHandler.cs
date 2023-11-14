using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.AuthorityCategorys.Requests.Commands;
using SchoolManagement.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.AuthorityCategorys.Handlers.Commands
{
    public class DeleteAuthorityCategoryCommandHandler : IRequestHandler<DeleteAuthorityCategoryCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteAuthorityCategoryCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteAuthorityCategoryCommand request, CancellationToken cancellationToken)
        {
            var AuthorityCategory = await _unitOfWork.Repository<AuthorityCategory>().Get(request.AuthorityCategoryId);

            if (AuthorityCategory == null)
                throw new NotFoundException(nameof(AuthorityCategory), request.AuthorityCategoryId);

            await _unitOfWork.Repository<AuthorityCategory>().Delete(AuthorityCategory);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
