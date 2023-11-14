﻿using MediatR;
using SchoolManagement.Application.DTOs.Branch;
using SchoolManagement.Application.DTOs.Complexion;
using SchoolManagement.Application.DTOs.Height;
using SchoolManagement.Application.DTOs.Weight;
using System;
using System.Collections.Generic;
using System.Text;
 
namespace SchoolManagement.Application.Features.Weights.Requests.Queries
{
    public class GetWeightsDetailRequest : IRequest<WeightDto> 
    {
        public int Id { get; set; } 
    }
}