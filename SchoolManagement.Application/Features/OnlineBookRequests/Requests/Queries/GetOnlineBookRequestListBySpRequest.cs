using MediatR;

namespace SchoolManagement.Application.Features.Demands.Requests.Queries
{
    public class GetOnlineBookRequestListBySpRequest : IRequest<object>
    {
        public int BaseSchoolNameId { get; set; }
        public string SearchText { get; set; }
    } 
} 
  
  