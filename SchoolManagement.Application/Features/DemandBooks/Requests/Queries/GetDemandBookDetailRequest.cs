using MediatR;
using SchoolManagement.Application.DTOs.DemandBook;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.DemandBooks.Requests.Queries
{
    public class GetDemandBookDetailRequest : IRequest<DemandBookDto>
    {
        public int DemandBookId { get; set; }
    }
}
