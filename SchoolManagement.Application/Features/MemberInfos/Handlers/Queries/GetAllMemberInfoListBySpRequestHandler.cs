using SchoolManagement.Application.Contracts.Persistence;
using MediatR;
using AutoMapper;
using SchoolManagement.Domain;
using SchoolManagement.Application.Features.MemberInfos.Requests.Queries;
using System.Data;

namespace SchoolManagement.Application.Features.MemberInfos.Handlers.Queries
{
    public class GetAllMemberInfoListBySpRequestHandler : IRequestHandler<GetAllMemberInfoListBySpRequest, object>
    {

        private readonly ISchoolManagementRepository<MemberInfo> _bookissueRepository;

        private readonly IMapper _mapper;
          
        public GetAllMemberInfoListBySpRequestHandler(ISchoolManagementRepository<MemberInfo> bookissueRepository, IMapper mapper)
        {
            _bookissueRepository = bookissueRepository;
            _mapper = mapper;
        }

        public async Task<object> Handle(GetAllMemberInfoListBySpRequest request, CancellationToken cancellationToken)
        {
            // object obj = new object();
            var spQuery = String.Format("exec [spGetAllMemberInfoList] '{0}'", request.SearchText);

            DataTable dataTable = _bookissueRepository.ExecWithSqlQuery(spQuery);

            return dataTable;

        }
    }
}
