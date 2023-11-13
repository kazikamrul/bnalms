using SchoolManagement.Application.Contracts.Persistence;
using MediatR;
using AutoMapper;
using SchoolManagement.Domain;
using System.Data;
using SchoolManagement.Application.Features.BookInformations.Requests.Queries;

namespace SchoolManagement.Application.Features.Demands.Handlers.Queries
{
    public class GetDamageByMemberListSpRequestHandler : IRequestHandler<GetDamageByMemberListSpRequest, object>
    {

        private readonly ISchoolManagementRepository<BookInformation> _bookInformationRepository;

        private readonly IMapper _mapper;

        public GetDamageByMemberListSpRequestHandler(ISchoolManagementRepository<BookInformation> bookInformationRepository, IMapper mapper)
        {
            _bookInformationRepository = bookInformationRepository;
            _mapper = mapper;
        }

        public async Task<object> Handle(GetDamageByMemberListSpRequest request, CancellationToken cancellationToken)
        {
           // object obj = new object();
            var spQuery = String.Format("exec [spGetDamageListByMember] {0}", request.MemberInfoId);

            DataTable dataTable = _bookInformationRepository.ExecWithSqlQuery(spQuery);
           
            return dataTable;
         
        }
    }
}
