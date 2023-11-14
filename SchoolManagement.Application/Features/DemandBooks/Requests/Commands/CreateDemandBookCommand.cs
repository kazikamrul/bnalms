using MediatR;
using SchoolManagement.Application.DTOs.DemandBook;
using SchoolManagement.Application.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.DemandBooks.Requests.Commands
{
    public class CreateDemandBookCommand : IRequest<BaseCommandResponse>
    {
        public CreateDemandBookDto DemandBookDto { get; set; }
    }
}
