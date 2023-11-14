using MediatR;
using SchoolManagement.Shared.Models;
using System.Collections.Generic;

namespace SchoolManagement.Application.Features.BookInformations.Requests.Queries
{
    public class GetOnlineBookRequestIsExistCheckRequest : IRequest<bool>
    {
        public int Pno { get; set; }
        public int BookInformationId { get; set; }
        public int RequestStatus { get; set; }
        public int CancelStatus { get; set; }
    }
} 
 