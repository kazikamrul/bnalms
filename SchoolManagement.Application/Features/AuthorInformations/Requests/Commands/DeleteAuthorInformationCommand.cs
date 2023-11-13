using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.AuthorInformations.Requests.Commands
{
    public class DeleteAuthorInformationCommand : IRequest
    {
        public int AuthorInformationId { get; set; }
    }
}
