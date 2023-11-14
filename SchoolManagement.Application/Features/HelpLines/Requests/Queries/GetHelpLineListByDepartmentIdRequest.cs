using MediatR;
using SchoolManagement.Application.DTOs.HelpLine;

namespace SchoolManagement.Application.Features.HelpLines.Requests.Queries
{
    public class GetHelpLineListByDepartmentIdRequest : IRequest<List<HelpLineDto>>
    {
        
        public int BaseSchoolNameId { get; set; }
    } 
}

