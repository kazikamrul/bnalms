using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.MemberInfos.Requests.Commands;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.MemberInfos.Handlers.Commands
{
    public class InActiveMemberInfoCommandHandler : IRequestHandler<InActiveMemberInfoCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public InActiveMemberInfoCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(InActiveMemberInfoCommand request, CancellationToken cancellationToken)
        {
            var MemberInfo = await _unitOfWork.Repository<MemberInfo>().Get(request.MemberInfoId);
            MemberInfo.EmpStatus = 0;

            if (MemberInfo == null)
                throw new NotFoundException(nameof(MemberInfo), request.MemberInfoId);

            await _unitOfWork.Repository<MemberInfo>().Update(MemberInfo);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
