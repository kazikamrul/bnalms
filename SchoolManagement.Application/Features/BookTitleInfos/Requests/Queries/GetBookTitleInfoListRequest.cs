using MediatR;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.DTOs.BookTitleInfo;
using SchoolManagement.Application.Models;

namespace SchoolManagement.Application.Features.BookTitleInfos.Requests.Queries
{
    public class GetBookTitleInfoListRequest : IRequest<PagedResult<BookTitleInfoDto>>
    {
        public QueryParams QueryParams { get; set; }
    }
}
