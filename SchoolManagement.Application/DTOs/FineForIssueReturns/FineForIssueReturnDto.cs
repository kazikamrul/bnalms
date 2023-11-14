using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.FineForIssueReturns
{
    public class FineForIssueReturnDto : IFineForIssueReturnDto
    {
        public int FineForIssueReturnId { get; set; }
        public int? BaseSchoolNameId { get; set; }
        public double? Amount { get; set; }
        public int? MenuPosition { get; set; }
        public DateTime? DateCreated { get; set; }
        public bool IsActive { get; set; }
        public int? BookIssueAndSubmissionId { get; set; }
    }
}
