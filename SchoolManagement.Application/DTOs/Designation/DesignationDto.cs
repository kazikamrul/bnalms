﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.Designation
{
    public class DesignationDto : IDesignationDto
    {
        public int DesignationId { get; set; }
        public string? DesignationName { get; set; }
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }
    }
}
