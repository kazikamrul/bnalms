using MediatR;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.DTOs.BookBindingInfo;
using SchoolManagement.Application.Models;

namespace SchoolManagement.Application.Features.BookBindingInfos.Requests.Queries
{
    public class GetBookBindingInfoListRequest : IRequest<PagedResult<BookBindingInfoDto>>
    {
        public QueryParams QueryParams { get; set; }
    }
}
