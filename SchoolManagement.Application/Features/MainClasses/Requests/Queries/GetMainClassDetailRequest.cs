using MediatR;
using SchoolManagement.Application.DTOs.MainClass;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.MainClasses.Requests.Queries
{
    public class GetMainClassDetailRequest : IRequest<MainClassDto>
    {
        public int MainClassId { get; set; }
    }
}
