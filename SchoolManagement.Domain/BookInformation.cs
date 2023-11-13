using SchoolManagement.Domain.Common;

namespace SchoolManagement.Domain
{
    public class BookInformation : BaseDomainEntity
    {
        public BookInformation()
        {

            AuthorInformations = new HashSet<AuthorInformation>();
            PublishersInformations = new HashSet<PublishersInformation>();
            SupplierInformations = new HashSet<SupplierInformation>();
            SourceInformations = new HashSet<SourceInformation>();
            MemberInfos = new HashSet<MemberInfo>();
            OnlineBookRequests = new HashSet<OnlineBookRequest>();
            BookBindingInfos = new HashSet<BookBindingInfo>();
            DamageInformationByLibraries = new HashSet<DamageInformationByLibrary>();
            BookIssueAndSubmissions = new HashSet<BookIssueAndSubmission>();
            MemberRegistrations = new HashSet<MemberRegistration>();
            FeeInformations = new HashSet<FeeInformation>();
        }

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
        public int? AdminDamageStatus { get; set; } 
        public int? BorrowerDamageStatus { get; set; } 
        public double? BorrowerDamageFineAmount { get; set; } 
        public string? BorrowerDamageRemarks { get; set; } 
        public DateTime? BorrowerDamageDate { get; set; } 
        public string? Notes { get; set; }
        public double? Price { get; set; }
        public int? CountOnlineRequest { get; set; }
        public int? SourceId { get; set; }
        public int? Mearge { get; set; }
        public string? MergeId { get; set; }
        public DateTime? AccessionDate { get; set; }
        public string? UseableDays { get; set; }
        public int? AuthorDamageStatus { get; set; }
        public string? Reason { get; set; }
        public DateTime? DamageDate { get; set; }
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }
        public int? IssueStatus { get; set; }   
        public int? MemberInfoId { get; set; }  
        public int? BookIssueAndSubmissionId { get; set; }  
        public int? BookBindingStatus { get; set; } 

        public virtual BookCategory? BookCategory { get; set; }
        public virtual BookTitleInfo? BookTitleInfo { get; set; }
        public virtual BaseSchoolName? BaseSchoolName { get; set; }
        public virtual MainClass? MainClass { get; set; }
        public virtual Language? Language { get; set; }
        public virtual RowInfo? RowInfo { get; set; }
        public virtual ShelfInfo? ShelfInfo { get; set; }
        public virtual Source? Source { get; set; }


        public virtual ICollection<DamageInformationByLibrary> DamageInformationByLibraries { get; set; }
        public virtual ICollection<BookBindingInfo> BookBindingInfos { get; set; }
        public virtual ICollection<FeeInformation> FeeInformations { get; set; }
        public virtual ICollection<BookIssueAndSubmission> BookIssueAndSubmissions { get; set; }
        public virtual ICollection<AuthorInformation> AuthorInformations { get; set; }
        public virtual ICollection<PublishersInformation> PublishersInformations { get; set; }
        public virtual ICollection<SupplierInformation> SupplierInformations { get; set; }
        public virtual ICollection<SourceInformation> SourceInformations { get; set; }
        public virtual ICollection<MemberInfo> MemberInfos { get; set; }
        public virtual ICollection<MemberRegistration> MemberRegistrations { get; set; }
        //public virtual ICollection<DamageInformationByLibrary>? DamageInformationByLibraries { get; set; }
        //public virtual ICollection<BookBindingInfo>? BookBindingInfos { get; set; }
        //public virtual ICollection<BookIssueAndSubmission>? BookIssueAndSubmissions { get; set; }
        //public virtual ICollection<AuthorInformation>? AuthorInformations { get; set; }
        //public virtual ICollection<PublishersInformation>? PublishersInformations { get; set; }
        //public virtual ICollection<SupplierInformation>? SupplierInformations { get; set; }
        //public virtual ICollection<SourceInformation>? SourceInformations { get; set; }
        //public virtual ICollection<MemberInfo>? MemberInfos { get; set; }
        public virtual ICollection<OnlineBookRequest> OnlineBookRequests { get; set; }


    }
}
