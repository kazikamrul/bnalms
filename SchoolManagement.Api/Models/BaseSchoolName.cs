using System;
using System.Collections.Generic;

namespace SchoolManagement.Api.Models
{
    public partial class BaseSchoolName
    {
        public BaseSchoolName()
        {
            AuthorInformations = new HashSet<AuthorInformation>();
            BookBindingInfos = new HashSet<BookBindingInfo>();
            BookInformations = new HashSet<BookInformation>();
            BookIssueAndSubmissions = new HashSet<BookIssueAndSubmission>();
            BookTitleInfos = new HashSet<BookTitleInfo>();
            Bulletins = new HashSet<Bulletin>();
            DamageInformationByLibraries = new HashSet<DamageInformationByLibrary>();
            EventInfos = new HashSet<EventInfo>();
            FeeInformations = new HashSet<FeeInformation>();
            FileInformations = new HashSet<FileInformation>();
            FineForIssueReturns = new HashSet<FineForIssueReturn>();
            HelpLines = new HashSet<HelpLine>();
            InformationFezups = new HashSet<InformationFezup>();
            Inventories = new HashSet<Inventory>();
            MemberInfos = new HashSet<MemberInfo>();
            MemberRegistrations = new HashSet<MemberRegistration>();
            NoticeInfos = new HashSet<NoticeInfo>();
            OnlineBookRequests = new HashSet<OnlineBookRequest>();
            PublishersInformations = new HashSet<PublishersInformation>();
            ReaderInformations = new HashSet<ReaderInformation>();
            SoftCopyUploads = new HashSet<SoftCopyUpload>();
            SourceInformations = new HashSet<SourceInformation>();
            SupplierInformations = new HashSet<SupplierInformation>();
        }

        public int BaseSchoolNameId { get; set; }
        public int? BaseNameId { get; set; }
        public string SchoolName { get; set; }
        public string ShortName { get; set; }
        public string SchoolLogo { get; set; }
        public int? Status { get; set; }
        public int? MenuPosition { get; set; }
        public string CreatedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public bool IsActive { get; set; }
        public string ContactPerson { get; set; }
        public string Address { get; set; }
        public string Telephone { get; set; }
        public string Cellphone { get; set; }
        public string Email { get; set; }
        public string Fax { get; set; }
        public int? BranchLevel { get; set; }
        public int? FirstLevel { get; set; }
        public int? SecondLevel { get; set; }
        public int? ThirdLevel { get; set; }
        public int? FourthLevel { get; set; }
        public int? FifthLevel { get; set; }
        public string ServerName { get; set; }

        public virtual ICollection<AuthorInformation> AuthorInformations { get; set; }
        public virtual ICollection<BookBindingInfo> BookBindingInfos { get; set; }
        public virtual ICollection<BookInformation> BookInformations { get; set; }
        public virtual ICollection<BookIssueAndSubmission> BookIssueAndSubmissions { get; set; }
        public virtual ICollection<BookTitleInfo> BookTitleInfos { get; set; }
        public virtual ICollection<Bulletin> Bulletins { get; set; }
        public virtual ICollection<DamageInformationByLibrary> DamageInformationByLibraries { get; set; }
        public virtual ICollection<EventInfo> EventInfos { get; set; }
        public virtual ICollection<FeeInformation> FeeInformations { get; set; }
        public virtual ICollection<FileInformation> FileInformations { get; set; }
        public virtual ICollection<FineForIssueReturn> FineForIssueReturns { get; set; }
        public virtual ICollection<HelpLine> HelpLines { get; set; }
        public virtual ICollection<InformationFezup> InformationFezups { get; set; }
        public virtual ICollection<Inventory> Inventories { get; set; }
        public virtual ICollection<MemberInfo> MemberInfos { get; set; }
        public virtual ICollection<MemberRegistration> MemberRegistrations { get; set; }
        public virtual ICollection<NoticeInfo> NoticeInfos { get; set; }
        public virtual ICollection<OnlineBookRequest> OnlineBookRequests { get; set; }
        public virtual ICollection<PublishersInformation> PublishersInformations { get; set; }
        public virtual ICollection<ReaderInformation> ReaderInformations { get; set; }
        public virtual ICollection<SoftCopyUpload> SoftCopyUploads { get; set; }
        public virtual ICollection<SourceInformation> SourceInformations { get; set; }
        public virtual ICollection<SupplierInformation> SupplierInformations { get; set; }
    }
}
