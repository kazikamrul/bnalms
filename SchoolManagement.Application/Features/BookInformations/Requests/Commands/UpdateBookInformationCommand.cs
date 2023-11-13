using MediatR;
using SchoolManagement.Application.DTOs.BookInformation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.BookInformations.Requests.Commands
{
    public class UpdateBookInformationCommand : IRequest<Unit>
    {
        public  BookInformationDto BookInformationDto { get; set; }
    }
}
