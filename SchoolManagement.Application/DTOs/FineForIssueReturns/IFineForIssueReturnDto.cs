using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.FineForIssueReturns 
{
    public interface IFineForIssueReturnDto 
    {
        public int FineForIssueReturnId { get; set; }
        public int? BaseSchoolNameId { get; set; }
        public double? Amount { get; set; }
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }
        public int? BookIssueAndSubmissionId { get; set; }
    } 
}
