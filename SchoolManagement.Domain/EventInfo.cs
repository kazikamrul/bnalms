using SchoolManagement.Domain;
using SchoolManagement.Domain.Common;
using System;
using System.Collections.Generic;

namespace SchoolManagement.Domain
{
    public class EventInfo:BaseDomainEntity
    {
        public EventInfo()
        {
            
        }

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
        public string? ApprovedName { get; set; }
        public DateTime? BudgetDate { get; set; }
        public string Remarks { get; set; }
        public bool IsActive { get; set; }

        public virtual BaseSchoolName BaseSchoolName { get; set; }
        
    }
}
