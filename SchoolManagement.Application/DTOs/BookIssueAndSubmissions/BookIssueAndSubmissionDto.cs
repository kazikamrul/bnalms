using SchoolManagement.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.BookIssueAndSubmission
{
    public class BookIssueAndSubmissionDto : IBookIssueAndSubmissionDto
    {
        public int BookIssueAndSubmissionId { get; set; }
        public int? BaseSchoolNameId { get; set; }
        public int MemberInfoId { get; set; }
        public int BookInformationId { get; set; }
        public int? ShelfInfoId { get; set; }
        public int? RowInfoId { get; set; }
        public DateTime? IssueDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public DateTime? SubmissionDate { get; set; }
        public double? FineForLate { get; set; }
        public double? FineForDamage { get; set; }
        public string? IsDamage { get; set; }
        public bool? BookStatus { get; set; }
        public DateTime? CancelDate { get; set; }
        public string? CancelId { get; set; }
        public int? OnlineRequested { get; set; }
        public DateTime? AcceptDate { get; set; }
        public DateTime? RequestDate { get; set; }
        public string? RemarksForIssue { get; set; }
        public int? MailTracking { get; set; }
        public bool? Seen { get; set; }
        public int? BorrowerDamageStatus { get; set; }
        public double? BorrowerDamageFineAmount { get; set; }
        public string? BorrowerDamageRemarks { get; set; }
        public double? IssueReturnFineAmount { get; set; }
        public DateTime? BorrowerDamageDate { get; set; }
        public string? RemarksForSubmission { get; set; }
        public DateTime? IssuedBy { get; set; }
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }

        public string? DepartmentName { get; set; }
        public string? Category { get; set; }
        public string? Pno { get; set; }
        public string? BookTitle { get; set; }
        public string? AccessionNo { get; set; }
        public  string? BaseSchoolName { get; set; }
        public string? BookInformation { get; set; } 
        public string? MemberInfo { get; set; }
        public string? RowInfo { get; set; }
        public string? ShelfInfo { get; set; }
        public string? BookTitleBangla { get; set; }

    }
}
