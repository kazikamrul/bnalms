﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.HelpLine
{
    public class HelpLineDto : IHelpLineDto
    {
        public int HelpLineId { get; set; }
        public int? BaseSchoolNameId { get; set; }
        public int? LibraryAuthorityId { get; set; }
        public string? HelpContact { get; set; }
        public string? EmailAddress { get; set; }
        public int? MenuPosition { get; set; }
        public bool? DashboardDisplayStatus { get; set; }
        public bool IsActive { get; set; }

        public string? SchoolName { get; set; }
        public string? ShortName { get; set; }
        public string? LibraryAuthority { get; set; }
    }
}
