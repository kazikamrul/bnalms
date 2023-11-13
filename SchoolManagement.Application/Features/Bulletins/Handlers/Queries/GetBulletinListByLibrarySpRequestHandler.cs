using SchoolManagement.Application.Contracts.Persistence;
using MediatR;
using AutoMapper;
using SchoolManagement.Domain;
using SchoolManagement.Application.Features.Bulletins.Requests.Queries;
using System.Data;

namespace SchoolManagement.Application.Features.Bulletins.Handlers.Queries
{
    public class GetBulletinListByLibrarySpRequestHandler : IRequestHandler<GetBulletinListByLibrarySpRequest, object>
    {

        private readonly ISchoolManagementRepository<Bulletin> _studentInfoByTraineeIdRepository;

        private readonly IMapper _mapper;

        public GetBulletinListByLibrarySpRequestHandler(ISchoolManagementRepository<Bulletin> studentInfoByTraineeIdRepository, IMapper mapper)
        {
            _studentInfoByTraineeIdRepository = studentInfoByTraineeIdRepository;
            _mapper = mapper;
        }

        public async Task<object> Handle(GetBulletinListByLibrarySpRequest request, CancellationToken cancellationToken)
        {
           // object obj = new object();
            var spQuery = String.Format("exec [spGetBulletinByLibrary] {0}", request.BaseSchoolNameId);
            
            DataTable dataTable = _studentInfoByTraineeIdRepository.ExecWithSqlQuery(spQuery);
           
            return dataTable;
         
        }
    }
}
