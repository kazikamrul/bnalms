using SchoolManagement.Application.Contracts.Persistence;
using MediatR;
using AutoMapper;
using SchoolManagement.Domain;
using SchoolManagement.Application.Features.OnlineBookRequests.Requests.Queries;
using System.Data;
using SchoolManagement.Application.Features.Demands.Requests.Queries;

namespace SchoolManagement.Application.Features.OnlineBookRequests.Handlers.Queries
{
    public class GetOnlineBookRequestListBySpRequestHandler : IRequestHandler<GetOnlineBookRequestListBySpRequest, object>
    {

        private readonly ISchoolManagementRepository<OnlineBookRequest> _onlineBookRequestByTraineeIdRepository;

        private readonly IMapper _mapper;

        public GetOnlineBookRequestListBySpRequestHandler(ISchoolManagementRepository<OnlineBookRequest> onlineBookRequestByTraineeIdRepository, IMapper mapper)
        {
            _onlineBookRequestByTraineeIdRepository = onlineBookRequestByTraineeIdRepository;
            _mapper = mapper;
        }

        public async Task<object> Handle(GetOnlineBookRequestListBySpRequest request, CancellationToken cancellationToken)
        {
            // object obj = new object();
            var spQuery = String.Format("exec [spGetOnlineBookRequestList] {0}, '{1}'", request.BaseSchoolNameId, request.SearchText);

            DataTable dataTable = _onlineBookRequestByTraineeIdRepository.ExecWithSqlQuery(spQuery);

            return dataTable;

        }
    }
}
