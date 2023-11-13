using MediatR;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.DTOs.OnlineBookRequest;
using SchoolManagement.Application.Models;

namespace SchoolManagement.Application.Features.OnlineBookRequests.Requests.Queries
{
    public class UserOnlineBookRequest : IRequest<Unit>
    {
        public int BookInformationId { get; set; }
        public int MemberInfoId { get; set; }
    }
}
