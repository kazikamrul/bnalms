using System;
using System.Collections.Generic;

namespace SchoolManagement.Api.Models
{
    public partial class BookIssueAndSubmission
    {
        public int BookIssueAndSubmissionId { get; set; }
        public int? BaseSchoolNameId { get; set; }
        public int MemberInfoId { get; set; }
        public int BookInformationId { get; set; }
        public int? RowInfoId { get; set; }
        public int? ShelfInfoId { get; set; }
        public DateTime? IssueDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public DateTime? SubmissionDate { get; set; }
        public double? FineForLate { get; set; }
        public double? FineForDamage { get; set; }
        public string IsDamage { get; set; }
        public bool? BookStatus { get; set; }
        public DateTime? CancelDate { get; set; }
        public string CancelId { get; set; }
        public int? OnlineRequested { get; set; }
        public DateTime? AcceptDate { get; set; }
        public DateTime? RequestDate { get; set; }
        public string RemarksForIssue { get; set; }
        public int? ReturnStatus { get; set; }
        public int? MailTracking { get; set; }
        public bool? Seen { get; set; }
        public int? BorrowerDamageStatus { get; set; }
        public double? BorrowerDamageFineAmount { get; set; }
        public DateTime? BorrowerDamageDate { get; set; }
        public string BorrowerDamageRemarks { get; set; }
        public string RemarksForSubmission { get; set; }
        public DateTime? IssuedBy { get; set; }
        public int? MenuPosition { get; set; }
        public string CreatedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public bool IsActive { get; set; }

        public virtual BaseSchoolName BaseSchoolName { get; set; }
        public virtual BookInformation BookInformation { get; set; }
        public virtual MemberInfo MemberInfo { get; set; }
        public virtual RowInfo RowInfo { get; set; }
        public virtual ShelfInfo ShelfInfo { get; set; }
    }
}
