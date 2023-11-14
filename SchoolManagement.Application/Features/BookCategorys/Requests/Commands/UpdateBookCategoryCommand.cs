using MediatR;
using SchoolManagement.Application.DTOs.BookCategory;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.BookCategorys.Requests.Commands
{
    public class UpdateBookCategoryCommand : IRequest<Unit>
    {
        public BookCategoryDto BookCategoryDto { get; set; }
    }
}
