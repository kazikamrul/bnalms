using MediatR;
using SchoolManagement.Application.DTOs.AuthorInformation;
using SchoolManagement.Application.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.AuthorInformations.Requests.Commands
{
    public class CreateAuthorInformationCommand : IRequest<BaseCommandResponse>
    {
        public CreateAuthorInformationDto AuthorInformationDto { get; set; }
    }
}
