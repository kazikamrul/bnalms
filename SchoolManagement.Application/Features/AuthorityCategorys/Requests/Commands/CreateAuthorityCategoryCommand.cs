using MediatR;
using SchoolManagement.Application.DTOs.AuthorityCategory;
using SchoolManagement.Application.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.AuthorityCategorys.Requests.Commands
{
    public class CreateAuthorityCategoryCommand : IRequest<BaseCommandResponse>
    {
        public CreateAuthorityCategoryDto AuthorityCategoryDto { get; set; }
    }
}
