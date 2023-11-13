using MediatR;
using SchoolManagement.Shared.Models;
using System.Collections.Generic;

namespace SchoolManagement.Application.Features.MemberInfos.Requests.Queries
{
    public class GetAutoCompletePNoRequest : IRequest<List<SelectedModel>>
    {
        public string Pno { get; set; }
    }
}
 