using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.MemberCategorys.Requests.Commands;
using SchoolManagement.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.MemberCategorys.Handlers.Commands
{
    public class DeleteMemberCategoryCommandHandler : IRequestHandler<DeleteMemberCategoryCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteMemberCategoryCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteMemberCategoryCommand request, CancellationToken cancellationToken)
        {
            var MemberCategory = await _unitOfWork.Repository<MemberCategory>().Get(request.MemberCategoryId);

            if (MemberCategory == null)
                throw new NotFoundException(nameof(MemberCategory), request.MemberCategoryId);

            await _unitOfWork.Repository<MemberCategory>().Delete(MemberCategory);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
