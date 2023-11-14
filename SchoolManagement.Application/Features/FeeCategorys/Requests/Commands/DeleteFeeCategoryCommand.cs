using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.FeeCategorys.Requests.Commands
{
    public class DeleteFeeCategoryCommand : IRequest
    {
        public int FeeCategoryId { get; set; }
    }
}
