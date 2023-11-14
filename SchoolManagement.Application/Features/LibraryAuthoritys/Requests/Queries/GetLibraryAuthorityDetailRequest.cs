using MediatR;
using SchoolManagement.Application.DTOs.LibraryAuthority;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.LibraryAuthoritys.Requests.Queries
{
    public class GetLibraryAuthorityDetailRequest : IRequest<LibraryAuthorityDto>
    {
        public int LibraryAuthorityId { get; set; }
    }
}
