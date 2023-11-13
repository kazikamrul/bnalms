﻿using System;
using System.Collections.Generic;

namespace SchoolManagement.Api.Models
{
    public partial class EventInfo
    {
        public int EventInfoId { get; set; }
        public int? BaseSchoolNameId { get; set; }
        public string EventName { get; set; }
        public string EventSubject { get; set; }
        public string EventPurpose { get; set; }
        public string EventLocation { get; set; }
        public int? EventGuest { get; set; }
        public string EventCharge { get; set; }
        public DateTime? EventFrom { get; set; }
        public DateTime? EventTo { get; set; }
        public int? Partcipant { get; set; }
        public double? EventBudget { get; set; }
        public double? ApproveBadget { get; set; }
        public string ApprovedName { get; set; }
        public DateTime? BudgetDate { get; set; }
        public string Remarks { get; set; }
        public string CreatedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public bool IsActive { get; set; }

        public virtual BaseSchoolName BaseSchoolName { get; set; }
    }
}
