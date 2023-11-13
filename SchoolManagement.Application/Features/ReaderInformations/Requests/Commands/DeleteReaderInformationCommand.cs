using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.ReaderInformations.Requests.Commands
{
    public class DeleteReaderInformationCommand : IRequest
    {
        public int ReaderInformationId { get; set; }
    }
}
