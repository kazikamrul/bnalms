using MediatR;
using SchoolManagement.Application.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.BookInformations.Requests.Commands
{
    public class DeleteBookInformationCommand : IRequest<BaseCommandResponse>
    {
        public int BookInformationId { get; set; }
    }
}
