using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.AuthorityCategorys.Requests.Commands
{
    public class DeleteAuthorityCategoryCommand : IRequest
    {
        public int AuthorityCategoryId { get; set; }
    }
}
