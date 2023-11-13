using MediatR;
using SchoolManagement.Shared.Models;
using System.Collections.Generic;

namespace SchoolManagement.Application.Features.OnlineBookRequests.Requests.Queries
{
    public class GetOnlineRequestIsExistCheckRequest : IRequest<bool>
    {
        public int BookInformationId { get; set; }
        public int MemberInfoId { get; set; }
    }
}
 