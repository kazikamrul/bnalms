using MediatR;
using SchoolManagement.Application.DTOs.AuthorityCategory;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.AuthorityCategorys.Requests.Commands
{
    public class UpdateAuthorityCategoryCommand : IRequest<Unit>
    {
        public AuthorityCategoryDto AuthorityCategoryDto { get; set; }
    }
}
