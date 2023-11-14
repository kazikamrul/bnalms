using MediatR;
using SchoolManagement.Application.DTOs.Bulletin;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.Bulletins.Requests.Commands
{
    public class UpdateBulletinCommand : IRequest<Unit>
    {
        public BulletinDto BulletinDto { get; set; }
    }
}
