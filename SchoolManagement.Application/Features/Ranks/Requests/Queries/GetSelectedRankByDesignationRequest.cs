using MediatR;
using SchoolManagement.Shared.Models;
using System.Collections.Generic;

namespace SchoolManagement.Application.Features.Ranks.Requests.Queries
{
    public class GetSelectedRankByDesignationRequest : IRequest<List<SelectedModel>>
    {
        public int DesignationId { get; set; }
    }
}
