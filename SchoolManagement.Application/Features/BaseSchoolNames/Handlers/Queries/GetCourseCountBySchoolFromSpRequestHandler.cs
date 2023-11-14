using SchoolManagement.Application.Contracts.Persistence;
using MediatR;
using AutoMapper;
using SchoolManagement.Domain;
using SchoolManagement.Application.Features.BaseSchoolNames.Requests.Queries;
using System.Data;

namespace SchoolManagement.Application.Features.BaseSchoolNames.Handlers.Queries
{
    public class GetCourseCountBySchoolFromSpRequestHandler : IRequestHandler<GetCourseCountBySchoolFromSpRequest, object>
    {

        private readonly ISchoolManagementRepository<BaseSchoolName> _baseSchoolNameRepository;

        private readonly IMapper _mapper;

        public GetCourseCountBySchoolFromSpRequestHandler(ISchoolManagementRepository<BaseSchoolName> baseSchoolNameRepository, IMapper mapper)
        {
            _baseSchoolNameRepository = baseSchoolNameRepository;
            _mapper = mapper;
        }

        public async Task<object> Handle(GetCourseCountBySchoolFromSpRequest request, CancellationToken cancellationToken)
        {

            var spQuery = String.Format("exec [spGetCourseCountBySchool]");

            DataTable dataTable = _baseSchoolNameRepository.ExecWithSqlQuery(spQuery);
            return dataTable;

        }
    }
}
