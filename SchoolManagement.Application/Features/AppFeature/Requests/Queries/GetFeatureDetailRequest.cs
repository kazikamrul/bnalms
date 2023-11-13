using MediatR;
using SchoolManagement.Application.DTOs.Branch;
using SchoolManagement.Application.DTOs.Features;
using System;
using System.Collections.Generic;
using System.Text;
 
namespace SchoolManagement.Application.Features.AppFeature.Requests.Queries
{
    public class GetFeatureDetailRequest : IRequest<FeatureDto> 
    {
        public int Id { get; set; } 
    }
}
