using System;
using System.Collections.Generic;

namespace SchoolManagement.Api.Models
{
    public partial class BookInformation
    {
        public BookInformation()
        {
            AuthorInformations = new HashSet<AuthorInformation>();
            BookBindingInfos = new HashSet<BookBindingInfo>();
            BookIssueAndSubmissions = new HashSet<BookIssueAndSubmission>();
            DamageInformationByLibraries = new HashSet<DamageInformationByLibrary>();
            FeeInformations = new HashSet<FeeInformation>();
            MemberInfos = new HashSet<MemberInfo>();
            MemberRegistrations = new HashSet<MemberRegistration>();
            OnlineBookRequests = new HashSet<OnlineBookRequest>();
            PublishersInformations = new HashSet<PublishersInformation>();
            SourceInformations = new HashSet<SourceInformation>();
            SupplierInformations = new HashSet<SupplierInformation>();
        }

        public int BookInformationId { get; set; }
        public int? BookCategoryId { get; set; }
        public int? LanguageId { get; set; }
        public int? MainClassId { get; set; }
        public int? RowInfoId { get; set; }
        public int? ShelfInfoId { get; set; }
        public int? BookTitleInfoId { get; set; }
        public int? BaseSchoolNameId { get; set; }
        public int? SourceId { get; set; }
        public int? Mearge { get; set; }
        public string CoverImage { get; set; }
        public string AccessionNo { get; set; }
        public string MergeId { get; set; }
        public int? Volume { get; set; }
        public string Heading { get; set; }
        public int? CallNumber { get; set; }
        public int? IsbnNo { get; set; }
        public string Edition { get; set; }
        public int? Issuable { get; set; }
        public int? PageNo { get; set; }
        public int? Illustrations { get; set; }
        public string Notes { get; set; }
        public double? Price { get; set; }
        public DateTime? AccessionDate { get; set; }
        public string UseableDays { get; set; }
        public int? AdminDamageStatus { get; set; }
        public int? BorrowerDamageStatus { get; set; }
        public double? BorrowerDamageFineAmount { get; set; }
        public DateTime? BorrowerDamageDate { get; set; }
        public string BorrowerDamageRemarks { get; set; }
        public int? CountOnlineRequest { get; set; }
        public int? IssueStatus { get; set; }
        public int? BookBindingStatus { get; set; }
        public int? AuthorDamageStatus { get; set; }
        public string Reason { get; set; }
        public DateTime? DamageDate { get; set; }
        public int? MenuPosition { get; set; }
        public string CreatedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public bool IsActive { get; set; }
        public int? MemberInfoId { get; set; }

        public virtual BaseSchoolName BaseSchoolName { get; set; }
        public virtual BookCategory BookCategory { get; set; }
        public virtual BookTitleInfo BookTitleInfo { get; set; }
        public virtual Language Language { get; set; }
        public virtual MainClass MainClass { get; set; }
        public virtual RowInfo RowInfo { get; set; }
        public virtual ShelfInfo ShelfInfo { get; set; }
        public virtual Source Source { get; set; }
        public virtual ICollection<AuthorInformation> AuthorInformations { get; set; }
        public virtual ICollection<BookBindingInfo> BookBindingInfos { get; set; }
        public virtual ICollection<BookIssueAndSubmission> BookIssueAndSubmissions { get; set; }
        public virtual ICollection<DamageInformationByLibrary> DamageInformationByLibraries { get; set; }
        public virtual ICollection<FeeInformation> FeeInformations { get; set; }
        public virtual ICollection<MemberInfo> MemberInfos { get; set; }
        public virtual ICollection<MemberRegistration> MemberRegistrations { get; set; }
        public virtual ICollection<OnlineBookRequest> OnlineBookRequests { get; set; }
        public virtual ICollection<PublishersInformation> PublishersInformations { get; set; }
        public virtual ICollection<SourceInformation> SourceInformations { get; set; }
        public virtual ICollection<SupplierInformation> SupplierInformations { get; set; }
    }
}
