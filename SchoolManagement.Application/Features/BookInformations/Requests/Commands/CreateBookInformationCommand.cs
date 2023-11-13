using MediatR;
using SchoolManagement.Application.DTOs.BookInformation;
using SchoolManagement.Application.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.BookInformations.Requests.Commands
{
    public class CreateBookInformationCommand : IRequest<BaseCommandResponse>
    {
        public CreateBookInformationDto BookInformationDto { get; set; }
    }
}
