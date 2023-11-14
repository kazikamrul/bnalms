using MediatR;
using SchoolManagement.Application.DTOs.ReaderInformation;
using SchoolManagement.Application.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.ReaderInformations.Requests.Commands
{
    public class CreateReaderInformationCommand : IRequest<BaseCommandResponse>
    {
        public CreateReaderInformationDto ReaderInformationDto { get; set; }
    }
}
