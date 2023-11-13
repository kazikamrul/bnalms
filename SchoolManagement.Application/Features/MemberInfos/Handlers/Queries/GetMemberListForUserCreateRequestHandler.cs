using SchoolManagement.Application.Contracts.Persistence;
using MediatR;
using AutoMapper;
using SchoolManagement.Domain;
using SchoolManagement.Application.Features.MemberInfos.Requests.Queries;
using System.Data;

namespace SchoolManagement.Application.Features.MemberInfos.Handlers.Queries
{
    public class GetMemberListForUserCreateRequestHandler : IRequestHandler<GetMemberListForUserCreateRequest, object>
    {

        private readonly ISchoolManagementRepository<MemberInfo> _MemberInfoRepository;

        private readonly IMapper _mapper;

        public GetMemberListForUserCreateRequestHandler(ISchoolManagementRepository<MemberInfo> MemberInfoRepository, IMapper mapper)
        {
            _MemberInfoRepository = MemberInfoRepository;
            _mapper = mapper;
        }

        public async Task<object> Handle(GetMemberListForUserCreateRequest request, CancellationToken cancellationToken)
        {

            var spQuery = String.Format("exec [spGetMemberListForUserCreate] '{0}'", request.Pno);

            DataTable dataTable = _MemberInfoRepository.ExecWithSqlQuery(spQuery);
            return dataTable;

        }
    }
}
