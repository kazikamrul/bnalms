using MediatR;
using SchoolManagement.Application.DTOs.BookCategory;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.BookCategorys.Requests.Queries
{
    public class GetBookCategoryDetailRequest : IRequest<BookCategoryDto>
    {
        public int BookCategoryId { get; set; }
    }
}
