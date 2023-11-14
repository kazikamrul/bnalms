using MediatR;
using SchoolManagement.Shared.Models;
using System;
using System.Collections.Generic;
using System.Text; 

namespace SchoolManagement.Application.Features.CourseDurations.Requests.Queries
{
    public class GetBaseSchoolNameByBaseNameIdRequest : IRequest<List<SelectedModel>>
    {
        public int BaseNameId { get; set; }    
    }
} 
