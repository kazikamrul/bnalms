using MediatR;
using SchoolManagement.Application.DTOs.OnlineBookRequest;

namespace SchoolManagement.Application.Features.OnlineBookRequests.Requests.Queries
{
    public class GetOnlineBookRequestListByBookInformationRequest : IRequest<List<OnlineBookRequestDto>>
    {
        public int BookInformationId { get; set; }
    }
}

 