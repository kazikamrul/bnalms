using MediatR;
using SchoolManagement.Application.DTOs.FeeInformation;
using SchoolManagement.Application.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.FeeInformations.Requests.Commands
{
    public class CreateFeeInformationCommand : IRequest<BaseCommandResponse>
    {
        public CreateFeeInformationDto FeeInformationDto { get; set; }
    }
}
