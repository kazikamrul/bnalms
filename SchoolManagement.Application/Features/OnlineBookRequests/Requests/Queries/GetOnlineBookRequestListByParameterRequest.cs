using MediatR;
using SchoolManagement.Application.DTOs.OnlineBookRequest;

namespace SchoolManagement.Application.Features.OnlineBookRequests.Requests.Queries
{
    public class GetOnlineBookRequestListByParameterRequest : IRequest<List<OnlineBookRequestDto>>
    {
        public int MemberInfoId { get; set; }
    }
}

  