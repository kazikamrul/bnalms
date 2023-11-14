using MediatR;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.DTOs.BookCategory;
using SchoolManagement.Application.Models;

namespace SchoolManagement.Application.Features.BookCategorys.Requests.Queries
{
    public class GetBookCategoryListRequest : IRequest<PagedResult<BookCategoryDto>>
    {
        public QueryParams QueryParams { get; set; }
    }
}
