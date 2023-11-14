using MediatR;
using SchoolManagement.Shared.Models;
using System.Collections.Generic;

namespace SchoolManagement.Application.Features.BookCategorys.Requests.Queries
{
    public class GetSelectedBookCategoryRequest : IRequest<List<SelectedModel>>
    {
    }
}
