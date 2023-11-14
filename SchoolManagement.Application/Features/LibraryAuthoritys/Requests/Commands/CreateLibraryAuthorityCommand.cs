using MediatR;
using SchoolManagement.Application.DTOs.LibraryAuthority;
using SchoolManagement.Application.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.LibraryAuthoritys.Requests.Commands
{
    public class CreateLibraryAuthorityCommand : IRequest<BaseCommandResponse>
    {
        public CreateLibraryAuthorityDto LibraryAuthorityDto { get; set; }
    }
}
