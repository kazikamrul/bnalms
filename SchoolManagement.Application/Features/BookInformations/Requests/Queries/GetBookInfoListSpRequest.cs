using MediatR;

namespace SchoolManagement.Application.Features.Demands.Requests.Queries
{
    public class GetBookInfoListSpRequest : IRequest<object>
    {
        public int BaseSchoolNameId { get; set; }
    } 
} 
 