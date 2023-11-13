using MediatR;
using SchoolManagement.Application.DTOs.Language;
using SchoolManagement.Application.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.Languages.Requests.Commands
{
    public class CreateLanguageCommand : IRequest<BaseCommandResponse>
    {
        public CreateLanguageDto LanguageDto { get; set; }
    }
}
