using MediatR;
using SchoolManagement.Shared.Models;
using System.Collections.Generic;

namespace SchoolManagement.Application.Features.BookTitleInfos.Requests.Queries
{
    public class GetAutoCompleteBookTitleRequest : IRequest<List<SelectedModel>>
    {
        public string Title { get; set; }
    }
}
 