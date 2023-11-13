using MediatR;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.DTOs.MainClass;
using SchoolManagement.Application.Models;

namespace SchoolManagement.Application.Features.MainClasses.Requests.Queries
{
    public class GetMainClassListRequest : IRequest<PagedResult<MainClassDto>>
    {
        public QueryParams QueryParams { get; set; }
    }
}
