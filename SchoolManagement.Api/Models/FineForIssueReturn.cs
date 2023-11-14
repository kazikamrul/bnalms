using System;
using System.Collections.Generic;

namespace SchoolManagement.Api.Models
{
    public partial class FineForIssueReturn
    {
        public int FineForIssueReturnId { get; set; }
        public int? BaseSchoolNameId { get; set; }
        public double? Amount { get; set; }
        public int? MenuPosition { get; set; }
        public string CreatedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public bool IsActive { get; set; }

        public virtual BaseSchoolName BaseSchoolName { get; set; }
    }
}
