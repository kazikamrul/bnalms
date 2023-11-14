using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.MemberInfos.Requests.Commands;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.MemberInfos.Handlers.Commands
{
    public class ActiveMemberInfoCommandHandler : IRequestHandler<ActiveMemberInfoCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ActiveMemberInfoCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(ActiveMemberInfoCommand request, CancellationToken cancellationToken)
        {
            var MemberInfo = await _unitOfWork.Repository<MemberInfo>().Get(request.MemberInfoId);
            MemberInfo.EmpStatus = 1;

            if (MemberInfo == null)
                throw new NotFoundException(nameof(MemberInfo), request.MemberInfoId);

            await _unitOfWork.Repository<MemberInfo>().Update(MemberInfo);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
