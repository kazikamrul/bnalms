using MediatR;
using SchoolManagement.Application.DTOs.AuthorInformation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.AuthorInformations.Requests.Commands
{
    public class UpdateAuthorInformationCommand : IRequest<Unit>
    {
        public AuthorInformationDto AuthorInformationDto { get; set; }
    }
}
