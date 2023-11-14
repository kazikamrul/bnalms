using MediatR;
using SchoolManagement.Shared.Models;
using System;
using System.Collections.Generic;
using System.Text; 

namespace SchoolManagement.Application.Features.RowInfos.Requests.Queries
{
    public class GetRowNameByShelfInfoIdRequest : IRequest<List<SelectedModel>>
    {
        public int ShelfInfoId { get; set; }    
    }
} 
