using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.Languages.Requests.Commands
{
    public class DeleteLanguageCommand : IRequest
    {
        public int LanguageId { get; set; }
    }
}
