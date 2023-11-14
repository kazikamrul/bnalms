using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.MemberRegistrations.Requests.Commands;
using SchoolManagement.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.MemberRegistrations.Handlers.Commands
{
    public class DeleteMemberRegistrationCommandHandler : IRequestHandler<DeleteMemberRegistrationCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteMemberRegistrationCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteMemberRegistrationCommand request, CancellationToken cancellationToken)
        {
            var MemberRegistration = await _unitOfWork.Repository<MemberRegistration>().Get(request.MemberRegistrationId);

            if (MemberRegistration == null)
                throw new NotFoundException(nameof(MemberRegistration), request.MemberRegistrationId);

            await _unitOfWork.Repository<MemberRegistration>().Delete(MemberRegistration);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
