using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.LibraryAuthoritys.Requests.Commands
{
    public class DeleteLibraryAuthorityCommand : IRequest
    {
        public int LibraryAuthorityId { get; set; }
    }
}
