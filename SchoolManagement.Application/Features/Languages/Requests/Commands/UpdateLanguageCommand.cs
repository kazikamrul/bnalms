using MediatR;
using SchoolManagement.Application.DTOs.Language;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.Languages.Requests.Commands
{
    public class UpdateLanguageCommand : IRequest<Unit>
    {
        public LanguageDto LanguageDto { get; set; }
    }
}
