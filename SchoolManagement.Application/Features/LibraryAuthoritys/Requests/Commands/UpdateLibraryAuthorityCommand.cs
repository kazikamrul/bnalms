using MediatR;
using SchoolManagement.Application.DTOs.LibraryAuthority;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.LibraryAuthoritys.Requests.Commands
{
    public class UpdateLibraryAuthorityCommand : IRequest<Unit>
    {
        public LibraryAuthorityDto LibraryAuthorityDto { get; set; }
    }
}
