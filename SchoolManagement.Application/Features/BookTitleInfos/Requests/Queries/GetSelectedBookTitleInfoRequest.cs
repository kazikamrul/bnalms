using MediatR;
using SchoolManagement.Shared.Models;
using System.Collections.Generic;

namespace SchoolManagement.Application.Features.BookTitleInfos.Requests.Queries
{
    public class GetSelectedBookTitleInfoRequest : IRequest<List<SelectedModel>>
    {
    }
}
