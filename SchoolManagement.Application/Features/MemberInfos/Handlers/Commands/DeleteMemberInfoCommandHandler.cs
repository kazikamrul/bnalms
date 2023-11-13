using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.MemberInfos.Requests.Commands;
using SchoolManagement.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.MemberInfos.Handlers.Commands
{
    public class DeleteMemberInfoCommandHandler : IRequestHandler<DeleteMemberInfoCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteMemberInfoCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteMemberInfoCommand request, CancellationToken cancellationToken)
        {
            var MemberInfo = await _unitOfWork.Repository<MemberInfo>().Get(request.MemberInfoId);

            if (MemberInfo == null)
                throw new NotFoundException(nameof(MemberInfo), request.MemberInfoId);

            await _unitOfWork.Repository<MemberInfo>().Delete(MemberInfo);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
