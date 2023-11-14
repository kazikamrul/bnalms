using MediatR;
using SchoolManagement.Application.DTOs.DemandBook;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.DemandBooks.Requests.Commands
{
    public class UpdateDemandBookCommand : IRequest<Unit>
    {
        public DemandBookDto DemandBookDto { get; set; }
    }
}
