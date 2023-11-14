using MediatR;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.DTOs.HelpLine;
using SchoolManagement.Application.Models;

namespace SchoolManagement.Application.Features.HelpLines.Requests.Queries
{
    public class GetHelpLineListRequest : IRequest<PagedResult<HelpLineDto>>
    {
        public QueryParams QueryParams { get; set; }
    }
}
