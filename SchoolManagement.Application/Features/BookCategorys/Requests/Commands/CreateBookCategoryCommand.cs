using MediatR;
using SchoolManagement.Application.DTOs.BookCategory;
using SchoolManagement.Application.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.BookCategorys.Requests.Commands
{
    public class CreateBookCategoryCommand : IRequest<BaseCommandResponse>
    {
        public CreateBookCategoryDto BookCategoryDto { get; set; }
    }
}
