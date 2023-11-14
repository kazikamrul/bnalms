using MediatR;
using SchoolManagement.Application.DTOs.FeeInformation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.FeeInformations.Requests.Commands
{
    public class UpdateFeeInformationCommand : IRequest<Unit>
    {
        public FeeInformationDto FeeInformationDto { get; set; }
    }
}
