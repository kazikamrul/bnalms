using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.FeeInformations.Requests.Commands
{
    public class DeleteFeeInformationCommand : IRequest
    {
        public int FeeInformationId { get; set; }
    }
}
