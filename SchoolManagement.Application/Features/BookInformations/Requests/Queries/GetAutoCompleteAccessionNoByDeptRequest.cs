using MediatR;
using SchoolManagement.Shared.Models;
using System.Collections.Generic;

namespace SchoolManagement.Application.Features.BookInformations.Requests.Queries
{
    public class GetAutoCompleteAccessionNoByDeptRequest : IRequest<List<SelectedModel>>
    {
        public string accessionNo { get; set; }
        public int DepartmentId { get; set; }
    }
}
 