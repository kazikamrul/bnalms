using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.Bulletins.Requests.Commands
{
    public class DeleteBulletinCommand : IRequest
    {
        public int BulletinId { get; set; }
    }
}
