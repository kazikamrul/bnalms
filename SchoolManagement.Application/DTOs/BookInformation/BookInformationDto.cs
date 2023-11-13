using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.BookInformation
{
    public class BookInformationDto : IBookInformationDto
    {
        public int BookInformationId { get; set; }
        public int? BookCategoryId { get; set; }
        public int? BaseSchoolNameId { get; set; }
        public int? LanguageId { get; set; }
        public int? MainClassId { get; set; }
        public int? RowInfoId { get; set; }
        public int? ShelfInfoId { get; set; }
        public int? BookTitleInfoId { get; set; }
        public string? CoverImage { get; set; }
        public string? AccessionNo { get; set; }
        public int? Volume { get; set; }
        public string? Heading { get; set; }
        public string? CallNumber { get; set; }
        public string? IsbnNo { get; set; }
        public string? Edition { get; set; }
        public int? Issuable { get; set; }
        public int? PageNo { get; set; }
        public int? Illustrations { get; set; }
        public string? Notes { get; set; }
        public double? Price { get; set; }
        public int? CountOnlineRequest { get; set; }
        public int? SourceId { get; set; }
        public int? Mearge { get; set; }
        public int? AdminDamageStatus { get; set; }
        public int? BorrowerDamageStatus { get; set; }
        public double? BorrowerDamageFineAmount { get; set; }
        public string? BorrowerDamageRemarks { get; set; }
        public DateTime? BorrowerDamageDate { get; set; }
        public DateTime? AccessionDate { get; set; }
        public string? UseableDays { get; set; }
        public int? AuthorDamageStatus { get; set; }
        public string? Reason { get; set; }
        public DateTime? DamageDate { get; set; }
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }
        public string? MergeId { get; set; }
        public int? IssueStatus { get; set; }
        public string? BookCategory { get; set; }
        public string? BookTitle { get; set; }
        public string? BookTitleEnglish { get; set; }
        public string? BookTitleBangla { get; set; }
        public string? MainClass { get; set; }
        public string? RowName { get; set; }
        public string? ShelfName { get; set; }
        public string? Language { get; set; }
        public string? Source { get; set; }
        public int? MemberInfoId { get; set; }
        public int? BookIssueAndSubmissionId { get; set; }
        public int? BookBindingStatus { get; set; }
        public IFormFile? Photo { get; set; }

    }
}
