using MediatR;
using SchoolManagement.Application.DTOs.Bulletin;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.Bulletins.Requests.Queries
{
    public class GetBulletinDetailRequest : IRequest<BulletinDto>
    {
        public int BulletinId { get; set; }
    }
}
