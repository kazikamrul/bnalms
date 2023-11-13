using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.BookCategorys.Requests.Commands
{
    public class DeleteBookCategoryCommand : IRequest
    {
        public int BookCategoryId { get; set; }
    }
}
