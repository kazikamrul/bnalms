using SchoolManagement.Application.Contracts.Persistence;
using MediatR;
using AutoMapper;
using SchoolManagement.Domain;
using SchoolManagement.Application.Features.BookBindingInfos.Requests.Queries;
using System.Data;
using SchoolManagement.Application.Features.BookInformations.Requests.Queries;

namespace SchoolManagement.Application.Features.BookBindingInfos.Handlers.Queries
{
    public class GetBookBindingInfoListBySpRequestHandler : IRequestHandler<GetBookBindingInfoListBySpRequest, object>
    {

        private readonly ISchoolManagementRepository<BookBindingInfo> _bookBindingInfoByTraineeIdRepository;

        private readonly IMapper _mapper;

        public GetBookBindingInfoListBySpRequestHandler(ISchoolManagementRepository<BookBindingInfo> bookBindingInfoByTraineeIdRepository, IMapper mapper)
        {
            _bookBindingInfoByTraineeIdRepository = bookBindingInfoByTraineeIdRepository;
            _mapper = mapper;
        }
         
        public async Task<object> Handle(GetBookBindingInfoListBySpRequest request, CancellationToken cancellationToken)
        {
            // object obj = new object();
            var spQuery = String.Format("exec [spGetBookBindingInfo] {0},'{1}'", request.BaseSchoolNameId, request.SearchText);

            DataTable dataTable = _bookBindingInfoByTraineeIdRepository.ExecWithSqlQuery(spQuery);

            return dataTable;

        }
    }
}
