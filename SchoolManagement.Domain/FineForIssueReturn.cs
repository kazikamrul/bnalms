using SchoolManagement.Domain.Common;
using System;
using System.Collections.Generic;

namespace SchoolManagement.Domain
{
    public class FineForIssueReturn:BaseDomainEntity
    {
        public int FineForIssueReturnId { get; set; }
        public int? BaseSchoolNameId { get; set; }
        public double? Amount { get; set; }
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }
        public int? BookIssueAndSubmissionId { get; set; }

        public virtual BaseSchoolName BaseSchoolName { get; set; }
    }
}
