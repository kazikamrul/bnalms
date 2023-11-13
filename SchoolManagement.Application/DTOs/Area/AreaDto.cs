using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.Area
{
    public class AreaDto : IAreaDto
    {
        public int AreaId { get; set; }
        public string? Name { get; set; }
        public bool IsActive { get; set; }
    }
}
