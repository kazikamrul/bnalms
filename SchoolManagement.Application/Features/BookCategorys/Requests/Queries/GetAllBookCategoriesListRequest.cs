using MediatR;
using SchoolManagement.Application.DTOs.BookCategory;
using SchoolManagement.Shared.Models;
using System.Collections.Generic;

namespace SchoolManagement.Application.Features.BookCategorys.Requests.Queries
{
    public class GetAllBookCategoriesListRequest : IRequest<List<BookCategoryDto>>
    {
    }
}
