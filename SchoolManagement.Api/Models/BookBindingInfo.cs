﻿using System;
using System.Collections.Generic;

namespace SchoolManagement.Api.Models
{
    public partial class BookBindingInfo
    {
        public int BookBindingInfoId { get; set; }
        public int? BaseSchoolNameId { get; set; }
        public int? BookInformationId { get; set; }
        public string PressName { get; set; }
        public int? PressNumber { get; set; }
        public DateTime? Date { get; set; }
        public string PressEmail { get; set; }
        public string PressAddress { get; set; }
        public string SenderOfficer { get; set; }
        public string OfficeDispiseNumber { get; set; }
        public string ReceivedOfficerName { get; set; }
        public string CreatedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public bool IsActive { get; set; }

        public virtual BaseSchoolName BaseSchoolName { get; set; }
        public virtual BookInformation BookInformation { get; set; }
    }
}
