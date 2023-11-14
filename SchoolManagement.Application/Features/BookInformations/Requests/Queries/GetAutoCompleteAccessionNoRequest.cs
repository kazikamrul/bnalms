using MediatR;
using SchoolManagement.Shared.Models;
using System.Collections.Generic;

namespace SchoolManagement.Application.Features.BookInformations.Requests.Queries
{
    public class GetAutoCompleteAccessionNoRequest : IRequest<List<SelectedModel>>
    {
        public string accessionNo { get; set; }
    }
}
 