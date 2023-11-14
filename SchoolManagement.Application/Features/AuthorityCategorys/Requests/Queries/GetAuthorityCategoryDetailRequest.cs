using MediatR;
using SchoolManagement.Application.DTOs.AuthorityCategory;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.AuthorityCategorys.Requests.Queries
{
    public class GetAuthorityCategoryDetailRequest : IRequest<AuthorityCategoryDto>
    {
        public int AuthorityCategoryId { get; set; }
    }
}
