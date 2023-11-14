using MediatR;
using SchoolManagement.Application.DTOs.ReaderInformation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.ReaderInformations.Requests.Commands
{
    public class UpdateReaderInformationCommand : IRequest<Unit>
    {
        public ReaderInformationDto ReaderInformationDto { get; set; }
    }
}
