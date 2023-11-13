using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.DemandBooks.Requests.Commands
{
    public class DeleteDemandBookCommand : IRequest
    {
        public int DemandBookId { get; set; }
    }
}
