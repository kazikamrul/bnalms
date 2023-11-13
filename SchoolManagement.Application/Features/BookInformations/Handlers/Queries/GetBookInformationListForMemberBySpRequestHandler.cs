using SchoolManagement.Application.Contracts.Persistence;
using MediatR;
using AutoMapper;
using SchoolManagement.Domain;
using SchoolManagement.Application.Features.BookInformations.Requests.Queries;
using System.Data;

namespace SchoolManagement.Application.Features.BookInformations.Handlers.Queries
{
    public class GetBookInformationListForMemberBySpRequestHandler : IRequestHandler<GetBookInformationListForMemberBySpRequest, object>
    {

        private readonly ISchoolManagementRepository<BookInformation> _studentInfoByTraineeIdRepository;

        private readonly IMapper _mapper;

        public GetBookInformationListForMemberBySpRequestHandler(ISchoolManagementRepository<BookInformation> studentInfoByTraineeIdRepository, IMapper mapper)
        {
            _studentInfoByTraineeIdRepository = studentInfoByTraineeIdRepository;
            _mapper = mapper;
        }

        public async Task<object> Handle(GetBookInformationListForMemberBySpRequest request, CancellationToken cancellationToken)
        {
            // object obj = new object();
            var spQuery = String.Format("exec [spGetBookInfoListForMemberTest] {0},{1},'{2}',{3},{4}", request.MemberInfoId, request.BaseSchoolNameId,request.SearchText,request.BookCategoryId,request.BookTitleInfoId);

            DataTable dataTable = _studentInfoByTraineeIdRepository.ExecWithSqlQuery(spQuery);

            return dataTable;

        }
    }
}
