﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.Rank
{
    public class RankDto : IRankDto
    {
        public int RankId { get; set; }
        public int? DesignationId { get; set; }
        public string? RankName { get; set; }
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }
        public string? Designation { get; set; }
    }
}
