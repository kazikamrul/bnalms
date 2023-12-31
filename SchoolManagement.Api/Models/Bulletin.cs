﻿using System;
using System.Collections.Generic;

namespace SchoolManagement.Api.Models
{
    public partial class Bulletin
    {
        public int BulletinId { get; set; }
        public int? BaseSchoolNameId { get; set; }
        public string BuletinDetails { get; set; }
        public string Status { get; set; }
        public int? MenuPosition { get; set; }
        public string CreatedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public bool IsActive { get; set; }

        public virtual BaseSchoolName BaseSchoolName { get; set; }
    }
}
